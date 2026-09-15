namespace SCAN
{ class Program
    {
        static void Main(string[] args)
        {
            //inicio
            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine($"Hello, welcome to the SCAN Console!");   

            //vareaveis
            string TexturePackSFSUtimate = "TexturePackSFSUtimate";
            string ModPartsSFS = "ModPartsSFS";

            //lista
            Console.WriteLine($"{TexturePackSFSUtimate}");
            Console.WriteLine($"{ModPartsSFS}");
            Console.WriteLine($"");
            
            //perguntando
            Console.WriteLine($"Enter the name corresponding to the mod");
            string modinstall = Console.ReadLine();

            //if e else
            if (modinstall == ModPartsSFS)
            {
                Console.WriteLine($"");
                
                Console.WriteLine($"{ModPartsSFS}, Intalled!");
                Console.WriteLine($"");
                
                Console.WriteLine($"Thanks for testing the SCAN Console :3");
                Console.ReadLine();
                
            }        
            
            else
            {
                Console.WriteLine($"");
                
                Console.WriteLine($"{TexturePackSFSUtimate}, Intalled!");
                Console.WriteLine($"");
                
                Console.WriteLine($"Thanks for testing the SCAN Console :3");
                Console.ReadLine();
                
            }

        }
    }
}
