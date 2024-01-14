﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Infrastructure.Database;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    [DbContext(typeof(RecipeDbContext))]
    [Migration("20240113122029_recipe_author")]
    partial class recipe_author
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MenuRecipe", b =>
                {
                    b.Property<int>("MenusId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesId")
                        .HasColumnType("int");

                    b.HasKey("MenusId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("MenuRecipe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Project.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageSrc = "/img/recipe/polevka.jpg",
                            Name = "Polévky"
                        },
                        new
                        {
                            Id = 2,
                            ImageSrc = "/img/recipe/maso.jpg",
                            Name = "Maso"
                        },
                        new
                        {
                            Id = 3,
                            ImageSrc = "/img/recipe/omacka.jpg",
                            Name = "Omáčky"
                        },
                        new
                        {
                            Id = 4,
                            ImageSrc = "/img/recipe/prilohy.jpg",
                            Name = "Přílohy"
                        },
                        new
                        {
                            Id = 5,
                            ImageSrc = "/img/recipe/testoviny.jpg",
                            Name = "Těstoviny"
                        },
                        new
                        {
                            Id = 6,
                            ImageSrc = "/img/recipe/moucniky.jpg",
                            Name = "Moučníky"
                        },
                        new
                        {
                            Id = 7,
                            ImageSrc = "/img/recipe/zelenina.jpg",
                            Name = "Zelenina"
                        },
                        new
                        {
                            Id = 8,
                            ImageSrc = "/img/recipe/ovoce.jpg",
                            Name = "Ovoce"
                        });
                });

            modelBuilder.Entity("Project.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RecipeOrder")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Project.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<int>("TimeForRecipe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Anonym",
                            Categories = "1,2",
                            Difficulty = "střední",
                            ImageSrc = "/img/recipe/vyvar.jpg",
                            Ingredients = "kuřecí křídla, mrkev, petržel, celer, cibule, česnek, bobkový list, pepř, nové koření, tymián",
                            Instructions = "Na sporák dejte velký hrnec, rozpalte ho a vhoďte do něj maso, mrkev, petržel, celer a cibuli. Nasucho opékejte aspoň pět minut dohněda; maso i zeleninu obracejte. Pak přidejte protlak a minutu ho nechte bublat\n\nVše zalijte dvěma litry studené vody. Pomocí pěnovačky (pokud ji nemáte, použijte lžíci) seberte z hladiny pěnu.\n\nVhoďte bobkový list, pepř, nové koření a tymián a přiveďte k varu. Pak oheň stáhněte naminimum a s částečně odkrytou poklicí vařte úplně mírným varem hodinu až dvě; čím delší var, tím silnější vývar získáte. (Hrnec také můžete dát do trouby předehřáté na 120 stupňů). Vývar průběžně kontrolujte a sbírejte případnou pěnu.\n\nHotový vývar sceďte přes hustý cedník (případně ho můžete vyložit navlhčenou utěrkou). Zeleninu vyhoďte; maso můžete obrat a použít do polévky.",
                            Name = "Kuřecí vývar",
                            Price = 85,
                            Rating = 4.5,
                            TimeForRecipe = 30
                        },
                        new
                        {
                            Id = 2,
                            Author = "Anonym",
                            Categories = "1,7",
                            Difficulty = "snadné",
                            ImageSrc = "/img/recipe/rajcatova_polevka.jpg",
                            Ingredients = "olivový olej, cibule, rajčata z konzervy, zeleninový vývar, bazalka, sůl, pepř",
                            Instructions = "V hrnci rozehřejte 2 lžíce olivového oleje na středním plameni.\n\nDo hrnce přidejte najemno nakrájené šalotky a opékejte 5–7 minut na středním plameni. K šalotkám přidejte utřený stroužek česneku a opékejte ještě další 1 minutu.\n\nPoté ztlumte plamen na mírný, přidejte krájená rajčata, 500 ml zeleninového vývaru, sůl a pepř a vařte 30 minut.\n\nNakonec směs rozmixujte. Hotovou polévku rozdělte do 4 talířů, ozdobte čerstvou bazalkou a podávejte.g",
                            Name = "Rajčatová polévka",
                            Price = 75,
                            Rating = 5.0,
                            TimeForRecipe = 15
                        },
                        new
                        {
                            Id = 3,
                            Author = "Anonym",
                            Categories = "2",
                            Difficulty = "snadné",
                            ImageSrc = "/img/recipe/kure.jpg",
                            Ingredients = "celé kuře,bobkový list, tymián, bazalka, vinný ocet, voda, sůl, pepř",
                            Instructions = "Horkovzdušnou troubu předehřejte na 150 °C.\n\nKuře osolte a opepřeteze všech stran.\n\nPřemístěte ho do pekáče a zalijte vinným octem, který rukama rovnoměrně rozetřete po celé ploše kuřete.\n\nTymián a bazalku nasekejte nadrobno.\n\nČástí bylinek potřete kuře a trochu dejte i dovnitř společně s celými bobkovými listy.\n\nKuře v odkrytém pekáči podlijte 300 ml vody a pečte při 150–160 °C 1,5 hodiny.\n\nPo této době zvyšte teplotu na 190–200 °C a kuře nechte ještě 30 minut dopékat.",
                            Name = "Pečené kuře",
                            Price = 150,
                            Rating = 4.0,
                            TimeForRecipe = 120
                        },
                        new
                        {
                            Id = 4,
                            Author = "Anonym",
                            Categories = "2,3,5",
                            Difficulty = "střední",
                            ImageSrc = "/img/recipe/rajska.jpg",
                            Ingredients = "olej, mrkev, celer, hovězí zadní, petržel, bílá cibule, rajčatový protlak, nové koření, bobkový list, těstoviny,máslo,sůl,pepř",
                            Instructions = "Ve větším hrnci si na středním plameni rozehřejte 2 lžíce olivového oleje, přidejte nakrájenou mrkev, celer a petržel a vše opékejte 4–5 minut.\n\nPoté do hrnce přidejte hovězí maso a opékejte ho 1–2 minuty z každé strany.\n\nNásledně přidejte nakrájenou cibuli, rajčatový protlak, bobkové listy, nové koření, skořici, třtinový cukr, sůl a pepř, zvyšte plamen na vysoký stupeň a vše opékejte 1–2 minuty.\n\nPoté do hrnce přidejte rajčata z plechovky a 950 ml vody, ztlumte plamen na mírný stupeň, hrnec přiklopte pokličkou a vařte 1–2 hodiny do změknutí masa – dostatečně uvařené maso poznáte tak, že když do něj píchnete nožem, hladce sjede z čepele.\n\nMezitím si uvařte těstoviny: v jiném hrnci si přiveďte k varu 2 l vody, osolte, přidejte těstoviny a vařte je na středním plameni po dobu uvedenou na obalu (obvykle se jedná o 5–8 minut).\n\nAž maso v hrnci změkne, vyndejte ho z hrnce, odložte stranou na talíř a nakrájejte na 4 kusy.\n\nPoté z hrnce odstraňte skořici, nové koření a bobkové listy a následně celý obsah hrnce rozmixujte dohladka ponorným mixérem.\n\nDo vzniklé směsi přidejte máslo a podle chuti sůl a pepř a ještě jednou promixujte.\n\nNyní si nachystejte 4 servírovací talíře a rozdělte do nich uvařené těstoviny.\n\nPoté do každého talíře přidejte rajčatovou omáčku z hrnce a 1 kus vařeného masa a podávejte.",
                            Name = "Rajská omáčka",
                            Price = 160,
                            Rating = 5.0,
                            TimeForRecipe = 60
                        },
                        new
                        {
                            Id = 5,
                            Author = "Anonym",
                            Categories = "6",
                            Difficulty = "střední",
                            ImageSrc = "/img/recipe/buchta.jpg",
                            Ingredients = "mouka, kypřící prášek, kakao,cukr,vejce,olej,mléko,tvaroh,vanilka",
                            Instructions = "Nejprve si předehřejte troubu na 180–190 °C.\n\nNachystejte si pekáč (30 cm × 40 cm) a vyložte jej pečicím papírem.\n\nPřipravte si těsto: Do mísy prosejte mouku, přidejte prášek do pečiva, kakao a cukr a promíchejte.\n\nNásledně přidejte 2 vejce, olej, 300 ml mléka a vše důkladně promíchejte, tak aby vzniklo hladké těsto. To poté nalijte do připraveného pekáče.\n\nNyní si připravte druhou mísu a v ní vyšlehejte tvaroh, vanilkový extrakt, 2 vejce a 150 ml mléka.\n\nTvarohovou směs následně naneste lžící na těsto v pekáči a rozprostřete ho po celém těstě tak, aby vzniklo mramorování – lžící přitom pohybujte do tvaru kříže.\n\nV posledním kroku vložte pekáč do vyhřáté trouby a buchtu pečte 25 minut na 180–190 °C.\n\nNásledně ji rozkrájejte na 15 kousků a podávejte.",
                            Name = "Tvarohová buchta",
                            Price = 50,
                            Rating = 5.0,
                            TimeForRecipe = 50
                        });
                });

            modelBuilder.Entity("Project.Domain.Entities.Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AutorId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Hodnoceni")
                        .HasColumnType("double");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AutorId = "1",
                            Hodnoceni = 4.5,
                            ImageSrc = "/img/recipe/vyvar.jpg",
                            Name = "Some Name",
                            Text = "Kuřecí vývar"
                        });
                });

            modelBuilder.Entity("Project.Infrastructure.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Project.Infrastructure.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                            Email = "admin@admin.cz",
                            EmailConfirmed = true,
                            FirstName = "Adminek",
                            LastName = "Adminovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.CZ",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                            Email = "manager@manager.cz",
                            EmailConfirmed = true,
                            FirstName = "Managerek",
                            LastName = "Managerovy",
                            LockoutEnabled = true,
                            NormalizedEmail = "MANAGER@MANAGER.CZ",
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        });
                });

            modelBuilder.Entity("MenuRecipe", b =>
                {
                    b.HasOne("Project.Domain.Entities.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Domain.Entities.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Project.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Project.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Project.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Project.Infrastructure.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Project.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("Project.Domain.Entities.Category", null)
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Project.Domain.Entities.Category", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
