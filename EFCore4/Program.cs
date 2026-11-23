using EFCore4.Context;

namespace EFCore4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new NationalBankContext();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================================================");
                Console.WriteLine("      National Bank - Management                     ");
                Console.WriteLine("=====================================================");
                Console.WriteLine("  1) Add a new Customer");
                Console.WriteLine("  2) Open a new Account for a Customer");
                Console.WriteLine("  3) Update Account Status (Active / Closed)");
                Console.WriteLine("  4) Remove an Account from a Customer");
                Console.WriteLine("  5) List all Customers (with accounts)");
                Console.WriteLine("  0) Exit");
                Console.WriteLine("-----------------------------------------------------");

                int choice = MethodHelpers.ReadInt("  Enter choice: ");
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        BankServices.AddNewCustomer(context);
                        break;
                    case 2:
                        BankServices.OpenNewAccount(context);
                        break;
                    case 3:
                        BankServices.UpdateAccountStatus(context);
                        break;
                    case 4:
                        BankServices.RemoveAccountFromCustomer(context);
                        break;
                    case 5:
                        BankServices.ListAllCustomers(context);
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
