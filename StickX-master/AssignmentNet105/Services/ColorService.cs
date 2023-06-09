﻿using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Data;
using AssignmentNet105_Shared.Models;
using IdGen;
using Microsoft.EntityFrameworkCore;

namespace AssignmentNet105.Services
{
	public class ColorService : IColorService
	{
		MyDbContext _context;
		public ColorService()
		{
			_context = new MyDbContext();
		}

		public async Task<bool> CreateColor(Color color)
        {
            if (color == null) return false;
            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();
            return true;
        }

		public async Task<bool> DeleteColor(Guid id)
        {
            try
            {
                var color = _context.Colors.Find(id);
                _context.Colors.Remove(color);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

		public async Task<List<Color>> GetAllColor()
		{
			return await _context.Colors.ToListAsync();
		}

		public async Task<Color> GetColorById(Guid id)
        {
            return await _context.Colors.AsQueryable().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

		public async Task<List<Color>> GetColorByName(string name)
		{
			return await _context.Colors.AsQueryable().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
		}

        public async Task<bool> UpdateColor(Color color)
        {
            try
            {
                var n = _context.Colors.Find(color.Id);
                n.Name = color.Name;
                n.Status = color.Status;
                _context.Update(n);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
	}
}
