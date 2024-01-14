using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AutorId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hodnoceni = table.Column<double>(type: "double", nullable: false),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instructions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeForRecipe = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Ingredients = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    Categories = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "9cf14c2c-19e7-40d6-b744-8917505c3106", "Admin", "ADMIN" },
                    { 2, "be0efcde-9d0a-461d-8eb6-444b043d6660", "Manager", "MANAGER" },
                    { 3, "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c", "admin@admin.cz", true, "Adminek", "Adminovy", true, null, "ADMIN@ADMIN.CZ", "ADMIN", "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==", null, false, "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6", false, "admin" },
                    { 2, 0, "7a8d96fd-5918-441b-b800-cbafa99de97b", "manager@manager.cz", true, "Managerek", "Managerovy", true, null, "MANAGER@MANAGER.CZ", "MANAGER", "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==", null, false, "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6", false, "manager" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageSrc", "Name" },
                values: new object[,]
                {
                    { 1, "/img/recipe/polevka.jpg", "Polévky" },
                    { 2, "/img/recipe/maso.jpg", "Maso" },
                    { 3, "/img/recipe/omacka.jpg", "Omáčky" },
                    { 4, "/img/recipe/prilohy.jpg", "Přílohy" },
                    { 5, "/img/recipe/testoviny.jpg", "Těstoviny" },
                    { 6, "/img/recipe/moucniky.jpg", "Moučníky" },
                    { 7, "/img/recipe/zelenina.jpg", "Zelenina" },
                    { 8, "/img/recipe/ovoce.jpg", "Ovoce" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Categories", "CategoryId", "Difficulty", "ImageSrc", "Ingredients", "Instructions", "Name", "Price", "Rating", "TimeForRecipe" },
                values: new object[,]
                {
                    { 1, "1,2", null, "střední", "/img/recipe/vyvar.jpg", "kuřecí křídla, mrkev, petržel, celer, cibule, česnek, bobkový list, pepř, nové koření, tymián", "Na sporák dejte velký hrnec, rozpalte ho a vhoďte do něj maso, mrkev, petržel, celer a cibuli. Nasucho opékejte aspoň pět minut dohněda; maso i zeleninu obracejte. Pak přidejte protlak a minutu ho nechte bublat\n\nVše zalijte dvěma litry studené vody. Pomocí pěnovačky (pokud ji nemáte, použijte lžíci) seberte z hladiny pěnu.\n\nVhoďte bobkový list, pepř, nové koření a tymián a přiveďte k varu. Pak oheň stáhněte naminimum a s částečně odkrytou poklicí vařte úplně mírným varem hodinu až dvě; čím delší var, tím silnější vývar získáte. (Hrnec také můžete dát do trouby předehřáté na 120 stupňů). Vývar průběžně kontrolujte a sbírejte případnou pěnu.\n\nHotový vývar sceďte přes hustý cedník (případně ho můžete vyložit navlhčenou utěrkou). Zeleninu vyhoďte; maso můžete obrat a použít do polévky.", "Kuřecí vývar", 85, 4.5, 30 },
                    { 2, "1,7", null, "snadné", "/img/recipe/rajcatova_polevka.jpg", "olivový olej, cibule, rajčata z konzervy, zeleninový vývar, bazalka, sůl, pepř", "V hrnci rozehřejte 2 lžíce olivového oleje na středním plameni.\n\nDo hrnce přidejte najemno nakrájené šalotky a opékejte 5–7 minut na středním plameni. K šalotkám přidejte utřený stroužek česneku a opékejte ještě další 1 minutu.\n\nPoté ztlumte plamen na mírný, přidejte krájená rajčata, 500 ml zeleninového vývaru, sůl a pepř a vařte 30 minut.\n\nNakonec směs rozmixujte. Hotovou polévku rozdělte do 4 talířů, ozdobte čerstvou bazalkou a podávejte.g", "Rajčatová polévka", 75, 5.0, 15 },
                    { 3, "2", null, "snadné", "/img/recipe/kure.jpg", "celé kuře,bobkový list, tymián, bazalka, vinný ocet, voda, sůl, pepř", "Horkovzdušnou troubu předehřejte na 150 °C.\n\nKuře osolte a opepřeteze všech stran.\n\nPřemístěte ho do pekáče a zalijte vinným octem, který rukama rovnoměrně rozetřete po celé ploše kuřete.\n\nTymián a bazalku nasekejte nadrobno.\n\nČástí bylinek potřete kuře a trochu dejte i dovnitř společně s celými bobkovými listy.\n\nKuře v odkrytém pekáči podlijte 300 ml vody a pečte při 150–160 °C 1,5 hodiny.\n\nPo této době zvyšte teplotu na 190–200 °C a kuře nechte ještě 30 minut dopékat.", "Pečené kuře", 150, 4.0, 120 },
                    { 4, "2,3,5", null, "střední", "/img/recipe/rajska.jpg", "olej, mrkev, celer, hovězí zadní, petržel, bílá cibule, rajčatový protlak, nové koření, bobkový list, těstoviny,máslo,sůl,pepř", "Ve větším hrnci si na středním plameni rozehřejte 2 lžíce olivového oleje, přidejte nakrájenou mrkev, celer a petržel a vše opékejte 4–5 minut.\n\nPoté do hrnce přidejte hovězí maso a opékejte ho 1–2 minuty z každé strany.\n\nNásledně přidejte nakrájenou cibuli, rajčatový protlak, bobkové listy, nové koření, skořici, třtinový cukr, sůl a pepř, zvyšte plamen na vysoký stupeň a vše opékejte 1–2 minuty.\n\nPoté do hrnce přidejte rajčata z plechovky a 950 ml vody, ztlumte plamen na mírný stupeň, hrnec přiklopte pokličkou a vařte 1–2 hodiny do změknutí masa – dostatečně uvařené maso poznáte tak, že když do něj píchnete nožem, hladce sjede z čepele.\n\nMezitím si uvařte těstoviny: v jiném hrnci si přiveďte k varu 2 l vody, osolte, přidejte těstoviny a vařte je na středním plameni po dobu uvedenou na obalu (obvykle se jedná o 5–8 minut).\n\nAž maso v hrnci změkne, vyndejte ho z hrnce, odložte stranou na talíř a nakrájejte na 4 kusy.\n\nPoté z hrnce odstraňte skořici, nové koření a bobkové listy a následně celý obsah hrnce rozmixujte dohladka ponorným mixérem.\n\nDo vzniklé směsi přidejte máslo a podle chuti sůl a pepř a ještě jednou promixujte.\n\nNyní si nachystejte 4 servírovací talíře a rozdělte do nich uvařené těstoviny.\n\nPoté do každého talíře přidejte rajčatovou omáčku z hrnce a 1 kus vařeného masa a podávejte.", "Rajská omáčka", 160, 5.0, 60 },
                    { 5, "6", null, "střední", "/img/recipe/buchta.jpg", "mouka, kypřící prášek, kakao,cukr,vejce,olej,mléko,tvaroh,vanilka", "Nejprve si předehřejte troubu na 180–190 °C.\n\nNachystejte si pekáč (30 cm × 40 cm) a vyložte jej pečicím papírem.\n\nPřipravte si těsto: Do mísy prosejte mouku, přidejte prášek do pečiva, kakao a cukr a promíchejte.\n\nNásledně přidejte 2 vejce, olej, 300 ml mléka a vše důkladně promíchejte, tak aby vzniklo hladké těsto. To poté nalijte do připraveného pekáče.\n\nNyní si připravte druhou mísu a v ní vyšlehejte tvaroh, vanilkový extrakt, 2 vejce a 150 ml mléka.\n\nTvarohovou směs následně naneste lžící na těsto v pekáči a rozprostřete ho po celém těstě tak, aby vzniklo mramorování – lžící přitom pohybujte do tvaru kříže.\n\nV posledním kroku vložte pekáč do vyhřáté trouby a buchtu pečte 25 minut na 180–190 °C.\n\nNásledně ji rozkrájejte na 15 kousků a podávejte.", "Tvarohová buchta", 50, 5.0, 50 }
                });

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "Id", "AutorId", "Hodnoceni", "ImageSrc", "Name", "Text" },
                values: new object[] { 1, "1", 4.5, "/img/recipe/vyvar.jpg", "Some Name", "Kuřecí vývar" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
