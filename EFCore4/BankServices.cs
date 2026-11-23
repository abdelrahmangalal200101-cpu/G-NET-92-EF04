using EFCore4.Context;
using EFCore4.Enteties;
using EFCore4.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace EFCore4
{
    internal static class BankServices
    {

        public static void AddNewCustomer(NationalBankContext context)
        {
            string fullName = MethodHelpers.ReadString("Enter Your FullName :-");
            int nationalId;
            while (true)
            {
                nationalId = MethodHelpers.ReadInt("Enter Your NationalId :-");
                if (nationalId < 100000000 || nationalId > 999999999)
                {
                    Console.WriteLine("National ID must be exactly 9 digits.");
                    continue;
                }
                if (context.Customers.Any(c => c.NationalId == nationalId))
                {
                    Console.WriteLine("This National ID already exists. Please enter a unique one.");
                    continue;
                }
                break;
            }
            DateTime dateOfBirth = MethodHelpers.ReadDate("Enter Date of Birth (yyyy-MM-dd): ");
            string email;
            while (true)
            {
                email = MethodHelpers.ReadString("Enter Email: ");
                if (!email.Contains("@") || !email.Contains("."))
                {
                    Console.WriteLine("Invalid email format. Please try again.");
                    continue;
                }
                if (context.Customers.Any(c => c.Email == email))
                {
                    Console.WriteLine("This Email is already registered. Please enter another one.");
                    continue;
                }
                break;
            }
            string phone;
            while (true)
            {
                phone = MethodHelpers.ReadString("Enter Phone Number: ");

                bool isValidLength = phone.Length == 11;
                bool isAllDigits = phone.All(char.IsDigit);
                bool isValidPrefix = phone.StartsWith("010") || phone.StartsWith("011") ||
                                     phone.StartsWith("012") || phone.StartsWith("015");

                if (!isValidLength || !isAllDigits || !isValidPrefix)
                {
                    Console.WriteLine("Invalid phone number. Must be 11 digits starting with 010, 011, 012, or 015.");
                    continue;
                }
                break;
            }
            string address = MethodHelpers.ReadString("Enter Your Address :-");
            CustomerType customerType = MethodHelpers.ReadCustomerType();
            var customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = customerType
            };
            context.Add(customer);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCustomer added successfully! Customer ID: {customer.Id}");
            Console.ResetColor();


            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        public static void OpenNewAccount(NationalBankContext context)
        {
            Console.WriteLine("--- Open New Account ---");

            int national = MethodHelpers.ReadInt("Enter Your NationalId :- ");
            var customer = context.Customers.FirstOrDefault(c => c.NationalId == national);

            if (customer == null)
            {
                Console.WriteLine("This National Id Not Found. Please add the customer first.");
                return;
            }

            var branches = context.Branches.ToList();
            if (!branches.Any())
            {
                Console.WriteLine("No branches available in the database.");
                return;
            }

            foreach (var branch in branches)
            {
                Console.WriteLine($"Branch Code: {branch.Code} - Name: {branch.Name}");
            }

            int branchChoice;
            while (true)
            {
                branchChoice = MethodHelpers.ReadInt("Choose the branch code you want :- ");
                if (!branches.Any(b => b.Code == branchChoice))
                {
                    Console.WriteLine("You Must Enter Valid Code For The Branch");
                    continue;
                }
                break;
            }

            var selectedBranch = branches.First(b => b.Code == branchChoice);

            decimal Balance;
            while (true) 
            {
                Balance = MethodHelpers.ReadDecimal("Enter Your Current Balance");
                if (Balance < 0)
                {
                    Console.WriteLine("Your Must Enter Invalid Balance > 0");
                    continue;
                }
                break;
            }

            DateTime openingDate = DateTime.Now;

            AccountType accountType = MethodHelpers.ReadAccountType();

            Console.WriteLine($"Validating branch '{selectedBranch.Code}' and customer #{customer.Id}...");

            var newAccount = new Account
            {
                CurrentBalance = Balance,
                OpeningDate = openingDate,
                BranchId = selectedBranch.Code,
                AccountType = accountType,
            };

            context.Accounts.Add(newAccount);
            context.SaveChanges();

            OwnerShipType ownerShipType = MethodHelpers.ReadOwnershipType();

            var customerAccount = new CustomerAccount
            {
                OwnerShipStartDate = DateTime.Now,
                AccountNumber = newAccount.AccountNumber,
                OwnerShipType = ownerShipType,
                AccountStatus = true,
                CustomerId = customer.Id,
            };

            context.CustomerAccounts.Add(customerAccount);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Account '{newAccount.AccountNumber}' created and linked to customer {customer.Id} as {ownerShipType} owner.");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();


        }

        public static void UpdateAccountStatus(NationalBankContext context)
        {
            Console.WriteLine("--- Update Account Status ---");
            int AccountNum = MethodHelpers.ReadInt("Enter Account Number :-");
            if (!context.Accounts.Any(a => a.AccountNumber == AccountNum))
            {
                Console.WriteLine("There is no Account With This Number");
                return;
            }
            int National = MethodHelpers.ReadInt("Enter Your NationalId :- ");
            var customer = context.Customers.FirstOrDefault(c => c.NationalId == National);

            if (customer == null)
            {
                Console.WriteLine("There is no Custoemr with This NationalId");
                return;
            }

            var customerAccount = context.CustomerAccounts.
                FirstOrDefault(ca => ca.AccountNumber == AccountNum && ca.CustomerId == customer.Id);
            if (customerAccount == null) 
            {
                Console.WriteLine("There is no Account Bellong to this user");
                return;
            }

            Console.WriteLine("New Status , 1 ) Opened , 2 ) Closed");
            int choice = MethodHelpers.ReadInt("Enter Your New Account Status");
            if (choice == 1)
            {
                if (customerAccount.AccountStatus == true)
                {
                    Console.WriteLine("This Account is already Active sir");
                }
                else
                {
                    customerAccount.AccountStatus = true;
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Updated Successfully Your Account Now Is Opened");
                    Console.ResetColor();
                }
            }
            else if (choice == 2)
            {
                if (customerAccount.AccountStatus == false)
                {
                    Console.WriteLine("This Account is already Closed sir");
                }
                else
                {
                    customerAccount.AccountStatus = false;
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Updated Successfully Your Account Now Is Closed");
                    Console.ResetColor();
                }
            }
            else 
            {
                Console.WriteLine("Invaild Number ");
                return;
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();


        }

        public static void RemoveAccountFromCustomer(NationalBankContext context)
        {
            Console.WriteLine("--- Remove Account From Customer ---");

            int AccountNum = MethodHelpers.ReadInt("Enter Account Number :-");
            if (!context.Accounts.Any(a => a.AccountNumber == AccountNum))
            {
                Console.WriteLine("There is no Account With This Number");
                return;
            }
            int National = MethodHelpers.ReadInt("Enter Your NationalId :- ");
            var customer = context.Customers.FirstOrDefault(c => c.NationalId == National);

            if (customer == null)
            {
                Console.WriteLine("There is no Custoemr with This NationalId");
                return;
            }

            var customerAccount = context.CustomerAccounts.
                FirstOrDefault(ca => ca.AccountNumber == AccountNum && ca.CustomerId == customer.Id);
            if (customerAccount == null)
            {
                Console.WriteLine("There is no Account Bellong to this user");
                return;
            }

            context.CustomerAccounts.Remove(customerAccount);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("OwnerShip Link Deleted");
            Console.ResetColor();

            bool hasOtherOwner = context.CustomerAccounts.Any(ca => ca.AccountNumber == AccountNum);
            if (!hasOtherOwner)
            {
                var account = context.Accounts.FirstOrDefault(a => a.AccountNumber == AccountNum);
                if (account != null)
                {
                    try
                    {
                        context.Accounts.Remove(account);
                        context.SaveChanges();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"That was the last owner – account '{AccountNum}' was also removed.");
                        Console.ResetColor();
                    }
                    catch (DbUpdateException)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"That was the last owner, but account '{AccountNum}' could not be deleted because it has existing transactions.");
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();

        }
    }
}
