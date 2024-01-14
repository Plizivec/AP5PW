using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Project.Infrastructure.Identity;
using System.Data;
using System.IO.Pipes;

namespace Project.Infrastructure.Database
{
    public class DatabaseInit
    {
        public IList<Category> GetCategories()
        {
            IList<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Polévky",
                ImageSrc = "/img/recipe/polevka.jpg",
            });
            categories.Add(new Category
            {
                Id = 2,
                Name = "Maso",
                ImageSrc = "/img/recipe/maso.jpg"
            });
            categories.Add(new Category
            {
                Id = 3,
                Name = "Omáčky",
                ImageSrc = "/img/recipe/omacka.jpg"
            });
            categories.Add(new Category
            {
                Id = 4,
                Name = "Přílohy",
                ImageSrc = "/img/recipe/prilohy.jpg"
            });
            categories.Add(new Category
            {
                Id = 5,
                Name = "Těstoviny",
                ImageSrc = "/img/recipe/testoviny.jpg"
            });
            categories.Add(new Category
            {
                Id = 6,
                Name = "Moučníky",
                ImageSrc = "/img/recipe/moucniky.jpg"
            });
            categories.Add(new Category
            {
                Id = 7,
                Name = "Zelenina",
                ImageSrc = "/img/recipe/zelenina.jpg"
            });
            categories.Add(new Category
            {
                Id = 8,
                Name = "Ovoce",
                ImageSrc = "/img/recipe/ovoce.jpg",
            });

            return categories;

        }


            public IList<Recipe> GetRecipes()
            {
                IList<Recipe> recipes = new List<Recipe>();

                IList<Category> categories = GetCategories();

                recipes.Add(new Recipe
                {
                    Id = 1,
                    Name = "Kuřecí vývar",
                    Instructions = "Na sporák dejte velký hrnec, rozpalte ho a vhoďte do něj maso, mrkev, petržel, celer a cibuli. Nasucho opékejte aspoň pět minut dohněda; maso i zeleninu obracejte. Pak přidejte protlak a minutu ho nechte bublat" +
                                    "\n\nVše zalijte dvěma litry studené vody. Pomocí pěnovačky (pokud ji nemáte, použijte lžíci) seberte z hladiny pěnu." +
                                    "\n\nVhoďte bobkový list, pepř, nové koření a tymián a přiveďte k varu. Pak oheň stáhněte naminimum a s částečně odkrytou poklicí vařte úplně mírným varem hodinu až dvě; čím delší var, tím silnější vývar získáte. (Hrnec také můžete dát do trouby předehřáté na 120 stupňů). Vývar průběžně kontrolujte a sbírejte případnou pěnu." +
                                    "\n\nHotový vývar sceďte přes hustý cedník (případně ho můžete vyložit navlhčenou utěrkou). Zeleninu vyhoďte; maso můžete obrat a použít do polévky.",
                    TimeForRecipe = 30,
                    Difficulty = "střední",
                    Price = 85,
                    Categories = new int[] { 1, 2 },
                    ImageSrc = "/img/recipe/vyvar.jpg",
                    Rating = 4.5,
                    Ingredients = "kuřecí křídla, mrkev, petržel, celer, cibule, česnek, bobkový list, pepř, nové koření, tymián",
                    Author = "Anonym",
                });


                recipes.Add(new Recipe
                {
                    Id = 2,
                    Name = "Rajčatová polévka",
                    Instructions = "V hrnci rozehřejte 2 lžíce olivového oleje na středním plameni.\n\n" +
                                    "Do hrnce přidejte najemno nakrájené šalotky a opékejte 5–7 minut na středním plameni. K šalotkám přidejte utřený stroužek česneku a opékejte ještě další 1 minutu.\n\n" +
                                    "Poté ztlumte plamen na mírný, přidejte krájená rajčata, 500 ml zeleninového vývaru, sůl a pepř a vařte 30 minut.\n\n" +
                                    "Nakonec směs rozmixujte. Hotovou polévku rozdělte do 4 talířů, ozdobte čerstvou bazalkou a podávejte.g",
                    TimeForRecipe = 15,
                    Difficulty = "snadné",
                    Price = 75,
                    Categories = new int[] { 1, 7 },
                    ImageSrc = "/img/recipe/rajcatova_polevka.jpg",
                    Rating = 5,
                    Ingredients = "olivový olej, cibule, rajčata z konzervy, zeleninový vývar, bazalka, sůl, pepř",
                    Author = "Anonym",
                });

                recipes.Add(new Recipe
                {
                    Id = 3,
                    Name = "Pečené kuře",
                    Instructions = "Horkovzdušnou troubu předehřejte na 150 °C.\n\n" +
                                    "Kuře osolte a opepřeteze všech stran.\n\n" +
                                    "Přemístěte ho do pekáče a zalijte vinným octem, který rukama rovnoměrně rozetřete po celé ploše kuřete.\n\n" +
                                    "Tymián a bazalku nasekejte nadrobno.\n\n" +
                                    "Částí bylinek potřete kuře a trochu dejte i dovnitř společně s celými bobkovými listy.\n\n" +
                                    "Kuře v odkrytém pekáči podlijte 300 ml vody a pečte při 150–160 °C 1,5 hodiny.\n\n" +
                                    "Po této době zvyšte teplotu na 190–200 °C a kuře nechte ještě 30 minut dopékat.",
                    TimeForRecipe = 120,
                    Difficulty = "snadné",
                    Price = 150,
                    Categories = new int[] { 2 },
                    ImageSrc = "/img/recipe/kure.jpg",
                    Rating = 4,
                    Ingredients = "celé kuře,bobkový list, tymián, bazalka, vinný ocet, voda, sůl, pepř",
                    Author = "Anonym",
                });

                recipes.Add(new Recipe
                {
                    Id = 4,
                    Name = "Rajská omáčka",
                    Instructions = "Ve větším hrnci si na středním plameni rozehřejte 2 lžíce olivového oleje, přidejte nakrájenou mrkev, celer a petržel a vše opékejte 4–5 minut.\n\n" +
                    "Poté do hrnce přidejte hovězí maso a opékejte ho 1–2 minuty z každé strany.\n\n" +
                    "Následně přidejte nakrájenou cibuli, rajčatový protlak, bobkové listy, nové koření, skořici, třtinový cukr, sůl a pepř, zvyšte plamen na vysoký stupeň a vše opékejte 1–2 minuty.\n\n" +
                    "Poté do hrnce přidejte rajčata z plechovky a 950 ml vody, ztlumte plamen na mírný stupeň, hrnec přiklopte pokličkou a vařte 1–2 hodiny do změknutí masa – dostatečně uvařené maso poznáte tak, že když do něj píchnete nožem, hladce sjede z čepele.\n\n" +
                    "Mezitím si uvařte těstoviny: v jiném hrnci si přiveďte k varu 2 l vody, osolte, přidejte těstoviny a vařte je na středním plameni po dobu uvedenou na obalu (obvykle se jedná o 5–8 minut).\n\n" +
                    "Až maso v hrnci změkne, vyndejte ho z hrnce, odložte stranou na talíř a nakrájejte na 4 kusy.\n\nPoté z hrnce odstraňte skořici, nové koření a bobkové listy a následně celý obsah hrnce rozmixujte dohladka ponorným mixérem.\n\n" +
                    "Do vzniklé směsi přidejte máslo a podle chuti sůl a pepř a ještě jednou promixujte.\n\n" +
                    "Nyní si nachystejte 4 servírovací talíře a rozdělte do nich uvařené těstoviny.\n\n" +
                    "Poté do každého talíře přidejte rajčatovou omáčku z hrnce a 1 kus vařeného masa a podávejte.",
                    TimeForRecipe = 60,
                    Difficulty = "střední",
                    Price = 160,
                    Categories = new int[] { 2, 3, 5 },
                    ImageSrc = "/img/recipe/rajska.jpg",
                    Rating = 5,
                    Ingredients = "olej, mrkev, celer, hovězí zadní, petržel, bílá cibule, rajčatový protlak, nové koření, bobkový list, těstoviny,máslo,sůl,pepř",
                    Author = "Anonym",
                });

                recipes.Add(new Recipe
                {
                    Id = 5,
                    Name = "Tvarohová buchta",
                    Instructions = "Nejprve si předehřejte troubu na 180–190 °C.\n\n" +
                    "Nachystejte si pekáč (30 cm × 40 cm) a vyložte jej pečicím papírem.\n\n" +
                    "Připravte si těsto: Do mísy prosejte mouku, přidejte prášek do pečiva, kakao a cukr a promíchejte.\n\n" +
                    "Následně přidejte 2 vejce, olej, 300 ml mléka a vše důkladně promíchejte, tak aby vzniklo hladké těsto. To poté nalijte do připraveného pekáče.\n\n" +
                    "Nyní si připravte druhou mísu a v ní vyšlehejte tvaroh, vanilkový extrakt, 2 vejce a 150 ml mléka.\n\n" +
                    "Tvarohovou směs následně naneste lžící na těsto v pekáči a rozprostřete ho po celém těstě tak, aby vzniklo mramorování – lžící přitom pohybujte do tvaru kříže.\n\n" +
                    "V posledním kroku vložte pekáč do vyhřáté trouby a buchtu pečte 25 minut na 180–190 °C.\n\n" +
                    "Následně ji rozkrájejte na 15 kousků a podávejte.",
                    TimeForRecipe = 50,
                    Difficulty = "střední",
                    Price = 50,
                    Categories = new int[] { 6 },
                    ImageSrc = "/img/recipe/buchta.jpg",
                    Rating = 5,
                    Ingredients = "mouka, kypřící prášek, kakao,cukr,vejce,olej,mléko,tvaroh,vanilka",
                    Author = "Anonym",
                });

                return recipes;
            }

            //for Identity tables


            public List<Role> CreateRoles()
            {
                List<Role> roles = new List<Role>();

                Role roleAdmin = new Role()
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
                };

                Role roleManager = new Role()
                {
                    Id = 2,
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
                };

                Role roleCustomer = new Role()
                {
                    Id = 3,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
                };


                roles.Add(roleAdmin);
                roles.Add(roleManager);
                roles.Add(roleCustomer);

                return roles;
            }


            public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
            {
                User admin = new User()
                {
                    Id = 1,
                    FirstName = "Adminek",
                    LastName = "Adminovy",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.cz",
                    NormalizedEmail = "ADMIN@ADMIN.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                    SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                    ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                };

                List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

                return (admin, adminUserRoles);
            }


            public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
            {
                User manager = new User()
                {
                    Id = 2,
                    FirstName = "Managerek",
                    LastName = "Managerovy",
                    UserName = "manager",
                    NormalizedUserName = "MANAGER",
                    Email = "manager@manager.cz",
                    NormalizedEmail = "MANAGER@MANAGER.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                    SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                    ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                };

                List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

                return (manager, managerUserRoles);
            }

            public IList<Tip> GetTips()
            {
                IList<Tip> tips = new List<Tip>();


                tips.Add(new Tip
                {
                    Id = 1,
                    Text = "Kuřecí vývar",
                    Name = "Some Name",
                    AutorId = "1",
                    Hodnoceni = 4.5,
                    ImageSrc = "/img/recipe/vyvar.jpg",
                });




                return tips;
            }
    }

} 

