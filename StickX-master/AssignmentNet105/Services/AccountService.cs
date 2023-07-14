﻿using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Data;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AssignmentNet105.Services
{
	public class AccountService : IAccountService
	{
		MyDbContext _context;
		public AccountService()
		{
			_context = new MyDbContext();
		}

		public async Task<AccountView> GetAccountById(Guid id)
        {
            List<AccountView> lstAccountView = new List<AccountView>();
            lstAccountView = await (
                from a in _context.Accounts
                join b in _context.Roles on a.RoleId equals b.Id
                join c in _context.Ranks on a.RankID equals c.Id
                where a.Id == id
                select new AccountView()
                {
                    Account = a,
                    Role = b,
                    Rank = c
                }).ToListAsync();
            return lstAccountView.AsQueryable().Where(p => p.Account.Id == id).FirstOrDefault();
		}

		public async Task<List<Account>> GetAllAccounts()
		{
			return await _context.Accounts.ToListAsync();
		}

		public async Task<bool> Login(LoginView account)
		{
			if (account == null) return false;
			var a = await _context.Accounts.AsQueryable().Where(p => p.UserName == account.UserName && p.PassWord == account.PassWord).SingleOrDefaultAsync();
			if(a == null) return false;
			return true;
		}

		public async Task<bool> Register(Account account)
		{
			if (account == null) return false;
			await _context.Accounts.AddAsync(account);
			await _context.SaveChangesAsync();
			return true;
		}

        public async Task<bool> UpdateAccount(UpdateAccount account)
        {
            try
            {
                var n = _context.Accounts.Find(account.Id);
                n.UserName = account.UserName;
                n.DateOfBirth = account.DateOfBirth;
                n.Gender = account.Gender;
                n.PhoneNumber = account.PhoneNumber;
                n.Email = account.Email;
                n.Address = account.Address;
                _context.Accounts.Update(n);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAccountPoint(AccountView account)
        {
            try
            {
                var n = _context.Accounts.Find(account.Account.Id);
                n.Point = account.Account.Point;
                if(account.Account.Point >= 2003)
                {
                    n.RankID = Guid.Parse("eaee20af-2adc-4b77-908a-67efb1188731");
                }
                else if(account.Account.Point >= 1000)
                {
                    n.RankID = Guid.Parse("eaee20af-2adc-4b77-908a-67efb1188732");
                }
                else if(account.Account.Point >= 500)
                {
                    n.RankID = Guid.Parse("eaee20af-2adc-4b77-908a-67efb1188733");
                }
                _context.Accounts.Update(n);
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
