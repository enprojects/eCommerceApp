using EntityFrameCoreReharsearsal.Model;
using EntityFrameCoreReharsearsal.Model.PepoleModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using API.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Core.Entities;
using System.Runtime.CompilerServices;

namespace EntityFrameCoreReharsearsal
{

    public class A
    {
        public int Number { get; set; }
        public A() : this(11)
        {

        }

        public A(int num)
        {
            Number = num;
        }
    }


    class Program
    {
        // this context shared among all application life time
        public static SamuraiContext _context = new SamuraiContext();
        public static PepoleContext _pepoleContext = new PepoleContext();
        public static StoreContext _storeContext = new StoreContext(() => {
          
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StoreDb");
            return builder.Options;

        });

        private static void Main(string[] args)
        {


            Expression<Func<int, bool>> leftExpression = x=>x>1;
            Expression<Func<int, bool>> rightExpression = x=>x<=8;
            var paramExpr = Expression.Parameter(typeof(int));
            

            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);

             

            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<int, bool>>(exprBody, paramExpr);

          var res =   finalExpr.Compile().Invoke(2);

            //var builder = new DbContextOptionsBuilder();
            //builder.UseSqlServer(
            //    "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = StoreDb");


            //var context = new StoreContext(builder.Options);

            //IQueryable<Product> prod = _storeContext.Products;

            //Console.WriteLine(prod.Expression);



            //var dd = _storeContext.Products.Where(x=>x.Id ==1);
            //dd.ToList();

            //   var a = new A();
            //   var ff = a.Number;
            //   //context.Database.EnsureCreated();
            //   GetSamurais("Before");
            //   //   AddSamurai();
            //   //  UpdateSamurai();
            //   //GetSamurais("After Add:");

            ////   InsertABattle();
            //   UpdateBatlle_Disconnected();
            //   Console.Write("Press any key...");
            //   Console.ReadKey();


            //if (_pepoleContext.People.Count()==0) {

            //    var json = System.IO.File.ReadAllText("pepole.json");
            //    var peoleObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(json);
            //    _pepoleContext.AddRange(peoleObj);
            //    _pepoleContext.SaveChanges();
            //}
            //var pepole = _pepoleContext.People.Include(x => x.Adresses).Include(x => x.Emails);

            //A v1 = new A() { };
            //A v2 = v1;

            //bool status1 = Object.ReferenceEquals(v1, v2);

            //A v3 = new A() { };
            //A v4 = null;

            //bool status2 = Object.ReferenceEquals(v3, v4);

            //    Expression<Func<int, bool>> left = x=> x >5;
            //    Expression<Func<int, bool>> right = x => x <=7;

            //    var andExpression = Expression.AndAlso(left.Body, right.Body);

            //    var e4 = Expression.Lambda<Func<int,  bool>>(andExpression, new[]
            //            {
            //    left.Parameters[0],
            //    right.Parameters[0]
            //});

            //    try
            //    {
            //        Func<int,  bool> res = e4.Compile();
            //        var ff = res(1);
            //    }
            //    catch (Exception e)
            //    {

            //        throw;
            //    }

            ///////////
            ///

            //var nums = new[] { 1, 2 };
            //var sum = nums.Aggregate(5, (a, b) => {
            //    var res = a + b; //a =5 b=1
            //    return res;
            //} , (a) => {

            //    return a+90;
            //});


            //Expression<Func<int, bool>> leftExpression = (x) => x > 3;
            //Expression<Func<int, bool>> rightExpression = (x) => x < 7;

            //var paramExpr = Expression.Parameter(typeof(int), "x");
            //var exprBody = Expression.And(leftExpression.Body, rightExpression.Body);
            //exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            //var finalExpr = Expression.Lambda<Func<int, bool>>(exprBody, paramExpr);

            //var fun = finalExpr.Compile();
            //var res = fun(1);


        }


        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Sampson" };
            _context.Samurais.AddRange(new List<Samurai> {
                new Samurai { Name = "Eyal" },
                new Samurai { Name = "Ninja fruit" },
                new Samurai { Name = "Some man" },
                new Samurai { Name = "Tasha" },
                new Samurai { Name = "command" },
            });
            _context.SaveChanges();
        }
        private static void UpdateSamurai()
        {
            var res = _context.Samurais.Where(x => x.Name == "Eyal").FirstOrDefault();
            res.Name = "yaa";

            _context.SaveChanges();
        }

        private static void InsertABattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "On the hills",
                StartDate = new DateTime(1550, 1, 1),
                EndDate = new DateTime(1550, 2, 1)
            });
            _context.SaveChanges();
        }


        private static void UpdateBatlle_Disconnected()
        {
            // dbx trackin ( connect context )- we dont have to to use  .Update
            //var battle = _context.Battles.First();
            //battle.Name = "222";            
            //_context.Battles.Update(battle);           
            // _context.SaveChanges();

            var battle = _context.Battles.First();
            battle.Name = "12345";
            _context.SaveChanges();
            using (var newCtx = new SamuraiContext())
            {

                //mark object state as update, withou update as mark, db context will not update context 
                //newCtx.Battles.Update(battle);
                // newCtx.SaveChanges();
            }
        }

        private static void GetSamurais(string text)
        {
            //   _context.Samurais.Where(s=>EF.Functions.Like()

            // var res = _context.Samurais.FirstOrDefault(x => x.Name == "Eyal"); //thrown exceptio, we should order before
            // var res = _context.Samurais.OrderBy(s => s.Name).FirstOrDefault(x => x.Name == "Eyal"); // work
            //  var res = _context.Samurais.Where(x => x.Name == "Eyal"); // work

            //  var samurais1 = _context.Samurais.Skip(1).Take(3).ToList();
            var samurais = _context.Samurais;


            var samuraisLst = _context.Samurais.ToList();

            Console.WriteLine($"{text}: Samurai count is {samuraisLst.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }


    }
}
