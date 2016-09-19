using System;
using System.Linq;
using System.Net.Mime;
using Identityserver_secure_api.Models;
using LiteDB;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LiteDatabase($"{AppDomain.CurrentDomain.BaseDirectory }..\\..\\OAuthDB.db"))
            {
                var client = db.GetCollection<ClientOAuth>("clientoauths");
                var scope = db.GetCollection<ScopeOAuth>("scopeoauths");
                int command = 0;
                do
                {
                    Menu();
                    command = Convert.ToInt32(Console.ReadLine());
                    Execute(command, client, scope);
                } while (command != 0);
            }
        }

        private static void Execute(int command, LiteCollection<ClientOAuth> client, LiteCollection<ScopeOAuth> scope)
        {
            switch (command)
            {
                case 0:
                    Environment.Exit(1);
                    break;
                case 1:
                    CreateClient(client);
                    break;
                case 2:
                    CreateScope(scope);
                    break;
                case 3:
                    AddScopeToClient(client, scope);
                    break;
                case 4:
                    GetAllClient(client);
                    break;
                case 5:
                    GetAllScope(scope);
                    break;
                case 6:
                    ClearClient(client);
                    break;
                default:
                    break;
            }
        }

        private static void ClearClient(LiteCollection<ClientOAuth> client)
        {
            client.Delete(Query.All());
        }

        private static void AddScopeToClient(LiteCollection<ClientOAuth> client, LiteCollection<ScopeOAuth> scope)
        {
            Console.WriteLine("-------scope---------");
            GetAllScope(scope);
            Console.WriteLine("-------client---------");
            GetAllClient(client);
            
            Console.WriteLine("choose scope id");
            var scopeId = int.Parse(Console.ReadLine());
            Console.WriteLine("choose client id");
            var clientId = int.Parse(Console.ReadLine());
        }

        private static void GetAllScope(LiteCollection<ScopeOAuth> scope)
        {
            var scopes = scope.FindAll().ToList();
            foreach (var scopeOAuth in scopes)
            {
                Console.WriteLine($"{scopeOAuth.Id}-{scopeOAuth.Name}-{scopeOAuth.PublicOnly}");
            }
        }

        private static void GetAllClient(LiteCollection<ClientOAuth> client)
        {
            var clients = client.FindAll().ToList();
            foreach (var clientOAuth in clients)
            {
                Console.WriteLine($"{clientOAuth.ClientId}-{clientOAuth.ClientSecret}");
            }
        }

        private static void CreateScope(LiteCollection<ScopeOAuth> scope)
        {
            Console.WriteLine("type 'create' to create new scope and 'exit' to exit method:");
            var input = Console.ReadLine();
            do
            {
                Console.WriteLine("enter scope name:");
                var scopeName = Console.ReadLine();
                if (scopeName != String.Empty)
                {
                    var newScope=new ScopeOAuth()
                    {
                        Name = scopeName
                    };
                    scope.Insert(newScope);
                    GetAllScope(scope);
                }
                input = Console.ReadLine();
            } while (input != "exit");
        }

        private static void CreateClient(LiteCollection<ClientOAuth> client)
        {
            Console.WriteLine("type 'create' to create new client and 'exit' to exit method:");
            var input = Console.ReadLine();
            do
            {
                var newClient = new ClientOAuth();
                newClient.ClientSecret = RandomString.Create();
                client.Insert(newClient);
                GetAllClient(client);
                input = Console.ReadLine();
            } while (input != "exit");
        }

        static void Menu()
        {
            Console.WriteLine("----------Management API Resoure-------");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Create Client and Secret key");
            Console.WriteLine("2.Create Scope");
            Console.WriteLine("3.Add scope to client");
            Console.WriteLine("4.Get all client");
            Console.WriteLine("5.Get all scope");
            Console.WriteLine("6.Clear client");
            Console.WriteLine("7.Clear scope");
            Console.WriteLine("Choose command:");
        }
    }
}
