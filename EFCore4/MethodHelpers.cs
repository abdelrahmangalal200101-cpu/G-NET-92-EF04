using EFCore4.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4
{
    public static class MethodHelpers
    {
        public static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Invalid number. Please enter a valid integer.");
            }
        }
        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
                    return result;

                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd (e.g., 1995-05-20).");
            }
        }
        public static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.WriteLine("Invalid amount. Please enter a valid number.");
            }
        }
        public static CustomerType ReadCustomerType()
        {
            while (true)
            {
                Console.Write("Select Customer Type (1 for Individual, 2 for Business): ");
                string? input = Console.ReadLine();

                if (input == "1") return CustomerType.Individual;
                if (input == "2") return CustomerType.Business;

                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }
        public static AccountType ReadAccountType()
        {
            while (true)
            {
                Console.Write("Select Account Type (1 for Savings, 2 for Cheking , 3 for Loan): ");
                string? input = Console.ReadLine();

                if (input == "1") return AccountType.Savings;
                if (input == "2") return AccountType.Checking;
                if (input == "3") return AccountType.Loan;

                Console.WriteLine("Invalid choice. Please enter 1 or 2 or 3.");
            }
        }
        public static OwnerShipType ReadOwnershipType()
        {
            while (true)
            {
                Console.Write("Select Ownership Role (1 for Primary, 2 for CoHolder): ");
                string? input = Console.ReadLine();

                if (input == "1") return OwnerShipType.Primary;
                if (input == "2") return OwnerShipType.CoHolder;

                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }
        public static TransactionType ReadTransactionType()
        {
            while (true)
            {
                Console.Write("Select Transaction Type (1 for Deposit, 2 for Withdraw , 3 for Transfer): ");
                string? input = Console.ReadLine();

                if (input == "1") return TransactionType.Diposite;
                if (input == "2") return TransactionType.Withdraw;
                if (input == "3") return TransactionType.Transfer;

                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }
        }

    }
}
