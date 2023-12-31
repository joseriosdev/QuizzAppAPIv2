﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Server.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace QuizzApp.Repositories.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuizApiContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(QuizApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Category> CreateCategoryAsync(CategoryDTO categoryDTO, CancellationToken cToken)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            category.CreatedAt = DateTime.UtcNow;
            await _context.Categories.AddAsync(category, cToken);
            await _context.SaveChangesAsync(cToken);
            return category;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cToken)
        {
            var categories = await _context.Categories.ToListAsync(cToken);
            return categories;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cToken)
        {
            Category? category = await _context.Categories.FindAsync(id, cToken);
            return category;
        }

        public async Task<Category?> GetCategoryByNameAsync(string? name, CancellationToken cToken)
        {
            Category? category = await _context.Categories
                .FirstOrDefaultAsync(cat => cat.Name == name, cToken);
            return category;
        }

        public async Task<Category> UpdateCategoryByIdAsync(int id, CategoryDTO categoryDTO, CancellationToken cToken)
        {
            Category? category = await _context.Categories.FindAsync(id, cToken);

            if(category is not null)
            {
                category!.Name = categoryDTO.Name;
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync(cToken);
                return category;
            }
            throw new Exception("Category is null or does not exists");
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id, CancellationToken cToken)
        {
            Category? category = await _context.Categories.FindAsync(id, cToken);
            if(category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cToken);
            return true;
        }
    }
}