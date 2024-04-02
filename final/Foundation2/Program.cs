using System;
//www.plantuml.com/plantuml/png/VP11ImCn48Nl-HKvAiK_i8Yqz225WWlLiqoJgGPdapKpEOZqlviqkqHXwot3lCpttbkpG9Gqa384pBgFmIOZwblTwLSF0tQQ9Jh_LcPdE-sybESOdScx4mMup9y9l3ZvgWArqbiWamW4duC0tTpEsfL-HEd1VEIREtyAPJCHpfE7RM890yPb4s1jHEPER-gZm7Qyyo-7JRbr384gvF3knl4gPVvU8Nc7AByn9eTfSr60u1z1I5vYqropCN4M73n5EuSSQ-qvrTwntFTrVBXmfZQwril_zRRaUpWYDN3hVc5tLclqDWtq0m00
class Program
{
    static void Main(string[] args)
    {
        // intialize an example order, with US shipping, and add four example products
        Order o1 = new Order(new Customer("Customer 1", new Address("1234 First Street","City 1","State 1","USA")));
        o1.AddProduct(new Product("Item 1", 00000001, 1.99, 1));
        o1.AddProduct(new Product("Item 2", 00000002, 2.99, 2));
        o1.AddProduct(new Product("Item 3", 00000003, 3.99, 3));
        o1.AddProduct(new Product("Item 4", 00000004, 4.99, 4));

        // intialize an example order, with non-US shipping, and add four example products
        Order o2 = new Order(new Customer("Customer 2", new Address("5678 Second Street","City 2","State 2","Not USA")));
        o2.AddProduct(new Product("Item 5", 00000005, 5.99, 5));
        o2.AddProduct(new Product("Item 6", 00000006, 6.99, 6));
        o2.AddProduct(new Product("Item 7", 00000007, 7.99, 7));
        o2.AddProduct(new Product("Item 8", 00000008, 8.99, 8));

        List<Order> ol = new List<Order> {o1, o2}; // list of the above two orders

        int i = 1; // order number to be displayed

        // display the order plus its total and its shipping and packing labels
        foreach (Order o in ol)
        {
            Console.WriteLine($"Order {i} (total: ${o.CalculateTotal()}):");
            Console.WriteLine($"{o.GetPackingLabel()}\n");
            Console.WriteLine($"Shipping Label:\n{o.GetShippingLabel()}\n");
            i++;
        }
    }
}