import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import {
  ModalDismissReasons,
  NgbActiveModal,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { ICategoryUpdate } from 'src/app/models/ICategoryUpdate';
import { CategoriesService } from 'src/app/services/categories.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-admin-category-actions',
  templateUrl: './admin-category-actions.component.html',
  styleUrls: ['./admin-category-actions.component.css'],
})
export class AdminCategoryActionsComponent implements OnInit {
  @Output('OnCategoryUpdated') categoryUpdatedEvent: EventEmitter<boolean> =
    new EventEmitter();

  @Input() categoryId!: number;

  closeResult: string = '';

  category: ICategoryUpdate = {
    id: 0,
    name: '',
  };

  constructor(
    private categoriesService: CategoriesService,
    private modalService: NgbModal,
    private toastService: ToastService
  ) {}

  onSubmit(updateProductForm: NgForm, modal: NgbActiveModal) {
    if (updateProductForm.invalid) return;

    this.categoriesService
      .updateCategory(this.category)
      .subscribe((response) => {
        if (response.succeeded) {
          this.toastService.showToast({
            icon: 'success',
            title: 'Kategori başarılı bir şekilde güncellendi.',
          });

          modal.dismiss();
          updateProductForm.reset();
          this.categoryUpdatedEvent.emit(true);
        } else {
          this.toastService.showToast({
            icon: 'error',
            title: 'Kategori güncellenirken hata oluştu.',
          });
        }
      });
  }

  ngOnInit() {}

  openModal(content: any) {
    this.getCategory();

    this.modalService
      .open(content, { ariaLabelledBy: 'modal-basic-title' })
      .result.then(
        (result) => {
          this.closeResult = `Closed with: ${result}`;
        },
        (reason) => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        }
      );
  }

  getCategory() {
    this.categoriesService
      .getCategory(this.categoryId)
      .subscribe((response) => {
        this.category.id = response.data.id;
        this.category.name = response.data.name;
      });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
