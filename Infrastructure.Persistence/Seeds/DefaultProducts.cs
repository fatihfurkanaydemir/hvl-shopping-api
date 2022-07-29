﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Newtonsoft.Json;

namespace Infrastructure.Persistence.Seeds
{
  public class DefaultProducts
  {
    public static async Task<bool> SeedAsync(IProductRepositoryAsync productRepository, ICategoryRepositoryAsync categoryRepository)
    {
      var mockData = File.ReadAllText(Path.Combine(
        Directory.GetCurrentDirectory(),
        @"../Infrastructure.Persistence/Seeds/PRODUCT_MOCK_DATA.json"));

      var deserializedMockData = JsonConvert.DeserializeObject<List<Product>>(mockData);

      var _item1 = deserializedMockData[0];

      var itemList = await productRepository.GetAllAsync();
      var _itemCount = itemList.Where(i => i.Name.StartsWith(_item1.Name)).Count();

      if (_itemCount > 0) // ALREADY SEEDED
        return true;

      try
      {
        foreach (var deserializedItem in deserializedMockData)
        {
          var category = await categoryRepository.GetByIdAsync(deserializedItem.Category.Id);

          await categoryRepository.MarkUnchangedAsync(category);
          deserializedItem.Category = category;

          await productRepository.AddAsync(deserializedItem);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }

      return true; // NOT ALREADY SEEDED
    }
  }
}
