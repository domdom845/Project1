using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace Shopping_List_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // mainhdhf

            LogoFrame();
            MenuFrame();
            Console.WriteLine("Your Choice: ");

            var y = Convert.ToChar(Console.ReadLine());
            start(y);


//Comments


        }

        static void LogoFrame()
        {
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("=                                    Welcome To Shopping List Manager                                                  =");
            Console.WriteLine("=                                     You have 0 items in your list                                                    =");
            Console.WriteLine("========================================================================================================================");
        }

        static void MenuFrame()
        {
            List<string> MenuOptions = new List<string>();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine();
            MenuOptions.Add("A   Add a new item");
            MenuOptions.Add("R   Remove an item");
            MenuOptions.Add("E   Edit an item");
            MenuOptions.Add("P   Mark an item as purchased");
            MenuOptions.Add("S   Sort the list");
            MenuOptions.Add("T   Toggle display of purchased items");
            MenuOptions.Add("Q   Quit the program");
            Console.WriteLine();

            foreach (string i in MenuOptions)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("***********************************************************************************************************************");
        }
        static void Priority(string value, string category)
        {
            var temp = "";
            var val = value;
            var cat = category;
            List<string> priorityList = new List<string>();
            Console.WriteLine("Name : " + val);
            Console.WriteLine("Category : " + cat);

            priorityList.Add("L: Low");
            priorityList.Add("M: Medium");
            priorityList.Add("H: High");

            foreach (string i in priorityList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Your Choice: ");
            var prior = Console.ReadLine();
            if (prior == "L")
            {
                temp = "Low";
            }

            if (prior == "M")
            {
                temp = "Medium";
            }
            if (prior == "H")
            {
                temp = "High";
            }
            Console.WriteLine(temp);
            Console.WriteLine("Item " + value + " added to list");

            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

            bool purchased = false;

            Random random = new Random();

            int generatedId1 = random.Next(10);
            int generatedId2 = random.Next(10);
            int generatedId3 = random.Next(10);

            int id = generatedId1 + generatedId2 + generatedId3;


            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = "Server=localhost;Database=mydatabase;Uid=root;Pwd=abc123;";


                Console.WriteLine("New Item Add");

                con.ConnectionString = "Server=localhost;Database=mydatabase;Uid=root;Pwd=abc123;";
                string sql = "INSERT INTO shoppinglist (id, Name, category,  priority, dateAdded, purchased) VALUES (@id, @Name,@category, @priority, @dateAdded, @purchased)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", value);
                cmd.Parameters.AddWithValue("@category", category);

                cmd.Parameters.AddWithValue("@priority", temp);
                cmd.Parameters.AddWithValue("@dateAdded", date);
                cmd.Parameters.AddWithValue("@purchased", purchased);


                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();



            }

        }

        static void ListFrame(string value)
        {
            var temp = "";
            List<string> Name = new List<string>();
            Console.WriteLine("Name " + value);
            Console.WriteLine();
            Name.Add("1: Food");
            Name.Add("2: Clothing");
            Name.Add("3: Furniture");
            Name.Add("4: Household");
            Name.Add("5: Jewelry");
            Name.Add("6: Utilities");
            Name.Add("7: Tech");
            Console.WriteLine();

            foreach (string i in Name)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("***********************************************************************************************************************");
        }
        static void start(char value)
        {
            switch (value)
            {
                case 'A':
                    add(value);

                    break;
                case 'R':
                    remove(value);
                    break;
                case 'E':
                    edit(value);
                    break;
                case 'P':
                    purchased(value);
                    break;
                case 'S':
                    sort(value);
                    break;
                case 'T':
                    toggle(value);
                    break;
                case 'Q':
                    quit(value);
                    break;
                default:
                    Console.WriteLine("Please try again!");
                    break;
            }



        }

        private static void quit(char value)
        {
            Console.WriteLine("Enter Item name");
            string str = Console.ReadLine();
        }

        private static void toggle(char value)
        {
            Console.WriteLine("Enter Item name");
            string str = Console.ReadLine();
        }

        private static void sort(char value)
        {
            Console.WriteLine("Enter Item name");
            string str = Console.ReadLine();
        }

        private static void purchased(char value)
        {
            Console.WriteLine("Enter Item name");
            string str = Console.ReadLine();
        }

        private static void edit(char value)
        {
            Console.WriteLine("Enter Item name");
            string str = Console.ReadLine();
        }

        private static void remove(char value)
        {
            Console.WriteLine("Select Item # to Remove");
            string str = Console.ReadLine();
            RemoveData(Convert.ToInt32(str));

        }

        private static void add(char value)
        {
            Console.WriteLine("Enter Item name");
            string str = Console.ReadLine();
            ListFrame(str);
            Console.WriteLine("Your Choice: ");
            var temp = Console.ReadLine();
            string choice = Condition(temp);
            Priority(str, choice);

        }
        private static string Condition(string value)
        {
            var temp = "";
            if (value == "1")
            {
                temp = "Food";
            }

            if (value == "2")
            {
                temp = "Clothing";
            }
            if (value == "3")
            {
                temp = "Furniture";
            }
            if (value == "4")
            {
                temp = "Household";
            }
            if (value == "5")
            {
                temp = "Jewelry";
            }
            if (value == "6")
            {
                temp = "Utilities";
            }
            if (value == "7")
            {
                temp = "Tech";

            }
            return temp;
        }
        public static void RemoveData(int id)
        {
            using (MySqlConnection con = new MySqlConnection())
            {
                Console.WriteLine("Item was removed ");

                con.ConnectionString = "Server=localhost;Database=mydatabase;Uid=root;Pwd=abc123;";

                string sql = "DELETE  FROM shoppinglist WHERE id =" + id + "";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
