using System.Collections.Generic;
using BlondsCooking.Helpers;
using BlondsCooking.LinearRegression;
using BlondsCooking.Models.Structure;
using BlondsCooking.Statistics;

namespace BlondsCooking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlondsCooking.Models.Db;

    internal sealed class Configuration : DbMigrationsConfiguration<BlondsCooking.Models.Db.BlondsCookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlondsCookingContext context)
        {
            AddOrUpdateCategories(context);
            context.SaveChanges();
            AddOrUpdateRecipes(context);
            context.SaveChanges();     
            AddOrUpdateIngredients(context);
            context.SaveChanges();

            //IngredientsPairingHelper helper = new IngredientsPairingHelper();
            //var test = helper.CalculatePercentagePairingForIngredient(new List<string>() { "kurczak", "oregano"});

            //var items = from pair in test orderby pair.Value descending select pair;
        }

        #region Categories

        private void AddOrUpdateCategories(BlondsCookingContext context)
        {
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Muffins"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Cookies"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Cakes"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Shakes"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Dinners"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Pancakes"
            });
            context.Categories.AddOrUpdate(category => category.Name, new Category()
            {
                Name = "Dishes"
            });
        }

        #endregion

        #region Recipes

        private void AddOrUpdateRecipes(BlondsCookingContext context)
        {
            DishParametersHelper dishParametersHelper = new DishParametersHelper();
            List<double[]> dishParameters = dishParametersHelper.CalculateParameterForDishes();
            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "FILETY Z KURCZAKA W SOSIE POMIDOROWYM Z MOZZARELLĄ",
                Image = "~/Images/Recipes/Dishes/1.jpg",
                SpicyValue = dishParameters[0][0],
                SaltyValue = dishParameters[0][1],
                BitterValue = dishParameters[0][2],
                SweetValue = dishParameters[0][3],
                MeatValue = dishParameters[0][4],
                SourValue = dishParameters[0][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,oregano,ostra papryka,szynka parmeńska,pomidor,mozzarella,bazylia",
                Ingredients = "2 pojedyncze filety z kurczaka, 1 łyżeczka suszonego oregano, szczypta ostrej papryki, 6 plasterków (ok. 80 g) szynki parmeńskiej lub serrano, 1 puszka pokrojonych pomidorów (polpa di pomodori), 1 kulka mozzarelli (użyłam mozzarelli di bufala), sól, pieprz, masło i oliwa extra vergine, bazylia",
                Description = "Filety z kurczaka oczyścić z błonek i kostek, opłukać. Każdy pokroić na 3 części w następujący sposób: filet położyć na deskę i przekroić pionowo na 2 części, jedną z tych części - grubszą - pokroić w poprzek na 2 cieńsze filety a drugą pozostawić w całości). Doprawić solą, pieprzem, suszonym oregano i ostrą papryką, wysmarować 2 łyżeczkami oliwy i zawinąć w plasterki szynki. Rozgrzać większą patelnię z pokrywą, włożyć 2 łyżki masła i 1 łyżkę oliwy extra vergine. Na rozgrzany tłuszcz włożyć filety i smażyć przez ok. 5 minut, w międzyczasie 2-3 razy przewrócić na drugą stronę. Stopniowo, łyżką wykładać pomidory i zagotować. Pomidory doprawić delikatnie solą, pieprzem i opcjonalnie szczyptą ostrej papryki. Gotować pod przykryciem przez ok. 6 minut, w międzyczasie filety przewrócić na drugą stronę. Dodać kawałki mozzarelli, przykryć i gotować jeszcze przez ok. 2 minuty aż ser się roztopi. Posypać bazylią i podawać. Można podgrzewać."

            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "FILETY Z KURCZAKA W PARMEZANOWEJ PANIERCE PIECZONE Z POMIDORAMI I SEREM",
                Image = "~/Images/Recipes/Dishes/2.jpg",
                SpicyValue = dishParameters[1][0],
                SaltyValue = dishParameters[1][1],
                BitterValue = dishParameters[1][2],
                SweetValue = dishParameters[1][3],
                MeatValue = dishParameters[1][4],
                SourValue = dishParameters[1][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,parmezan,pomidor,czerwona cebula,mozzarella,bazylia,tymianek,estragon,cukinia",
                Ingredients = "1 podwójna pierś kurczaka (użyłam zagrodowego), 3 łyżki masła, 1 łyżka oliwy extra vergine, 2/3 szklanki bułki tartej, 1/3 szklanki tartego parmezanu (lub grana padano), 2 większe pomidory, 1 mała czerwona cebula, 60 g tartego miękkiego sera (np. koziego, mozzarelli, provoletta), świeże zioła np. estragon, bazylia, tymianek, 2 cukinie",
                Description = "Piekarnik nagrzać do 220 stopni C. Rozdzielić filety kurczaka na 2 pojedyncze piersi. Każdy filet przekroić poziomo na 2 cieńsze filety i rozbić tłuczkiem w najgrubszej części na taką samą grubość (ok. 1/2 cm). Doprawić solą, pieprzem i posmarować roztopionym masłem wymieszanym z oliwą, następnie obtoczyć w mieszance tartej bułki i tartego parmezanu. Ułożyć na blaszce do pieczenia wysmarowanej oliwą. Wstawić do piekarnika i piec przez 15 minut. Pomidory sparzyć, obrać ze skórki, pokroić w kosteczkę odsączyć z nadmiaru soku, wymieszać z drobno posiekaną czerwoną cebulą. Piekarnik przełączyć na funkcję grilla (jeśli nie mamy takiej funkcji podnieść temp. do 240 st. C), na filetach położyć salsę pomidorową i tarty ser i wstawić do piekarnika. Grillować/piec jeszcze przez 5 minut. Posypać świeżymi ziołami. Podawać na tagliatelle z cukinii. Cukinię pokroić obieraczką do julienne i wrzucić na 1/2 minuty na wrzątek, odcedzić, doprawić łyżeczką oliwy, solą, pieprzem i posiekanymi ziołami."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "PULPECIKI Z ŁOSOSIA I KASZY JAGLANEJ ZE SZPINAKIEM (LUB JARMUŻEM)",
                Image = "~/Images/Recipes/Dishes/3.jpg",
                SpicyValue = dishParameters[2][0],
                SaltyValue = dishParameters[2][1],
                BitterValue = dishParameters[2][2],
                SweetValue = dishParameters[2][3],
                MeatValue = dishParameters[2][4],
                SourValue = dishParameters[2][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,szpinak,jarmuż,kasza jaglana,bazylia,szczypiorek,chili",
                Ingredients = "200 g filetu z łososia, 1 szklanka liści młodego szpinaku lub 2 liście jarmużu, 1/2 szklanki ugotowanej na sypko kaszy jaglanej, 1/2 szklanki liści bazylii, 1 szczypiorek, sól, pieprz, opcjonalnie kawałeczek chili, sok z cytryny, mąka do obtoczenia (użyłam ryżowej) oraz olej lub masło klarowane do smażenia (użyłam oleju kokosowego)",
                Description = "Odciąć skórę z łososia, sprawdzić czy nie ma ości, opłukać, pokroić na kilka mniejszych części. Szpinak opłukać, osuszyć, włożyć na patelnię i mieszając chwilę podgrzewać aż zwiędnie. Odcisnąć z wody. Jarmuż włożyć na wrzątek i gotować przez 5 minut lub ugotować na parze przez ok. 8 minut, odcedzić, pokroić na kilka mniejszych kawałków, osuszyć. Składniki na kotleciki rozdrabniamy/siekamy w rozdrabniaczu lub w melakserze lub siekamy na desce. Najpierw miksujemy kaszę, później dodajemy szpinak lub jarmuż, bazylię oraz posiekany szczypiorek, na koniec dodajemy łososia. Doprawić solą, pieprzem, chili jeśli używamy, skropić sokiem z cytryny i uformować kuleczki lub płaskie kotleciki. Obtoczyć je w mące (tak przygotowane można też schować do lodówki na kilka godzin). Obsmażyć na złoty kolor z każdej strony. Podawać z cząstką cytryny, jogurtem naturalnym oraz z sałatą z cukinią pokrojoną obieraczką do warzyw w cienkie tagliatelle, z pomidorkami koktajlowymi i winegretem miodowym."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "GRILLOWANE FILETY Z KURCZAKA Z KARMELIZOWANYMI ŚLIWKAMI",
                Image = "~/Images/Recipes/Dishes/4.jpg",
                SpicyValue = dishParameters[3][0],
                SaltyValue = dishParameters[3][1],
                BitterValue = dishParameters[3][2],
                SweetValue = dishParameters[3][3],
                MeatValue = dishParameters[3][4],
                SourValue = dishParameters[3][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,rozmaryn,słodka papryka,oliwa,śliwki,ostra papryka,miód,ocet balsamiczny",
                Ingredients = "1 pojedynczy filet z kurczaka, gałązka rozmarynu, 1/2 łyżeczki słodkiej papryki w proszku, 1 łyżeczka oliwy, sól, pieprz, sok z cytryny, z pomarańczy, 200 g śliwek (świeżych lub mrożonych), 2 łyżki cukru, szczypta ostrej papryki, 1 łyżka miodu, 4 łyżki octu balsamicznego, opcjonalnie 4 łyżki nalewki śliwkowej, wiśniowej lub brandy",
                Description = "Kurczaka pokroić na 4 fileciki, rozbić tłuczkiem na podobną grubość około 1 cm. Doprawić solą, pieprzem, słodką papryką, listkami rozmarynu, wymieszać z oliwą, odłożyć. Śliwki mrożone wcześniej rozmrozić, świeże umyć, pokroić na kawałki, usunąć pestki. Owoce włożyć do miseczki, dodać cukier, chili w proszku, odłożyć. Kaszę wsypać do garnka, dodać bulion lub wodę, doprawić w razie potrzeby solą, pieprzem i zagotować. Przykryć pokrywą i gotować na małym ogniu przez 20 minut, aż kasza wchłonie większość płynu, następnie zostawić pod przykryciem jeszcze na ok. 10 minut. Otworzyć garnek, dodać posiekany koperek i wymieszać. Ogórka umyć, obrać, obrać na paseczki obieraczką do warzyw, dodać obrane, pokrojone na kawałeczki awokado (lub ser feta), skropić sokiem z cytryny, doprawić pieprzem, odrobiną soli, posypać szczypiorkiem i listkami mięty. Rozgrzać patelnię grillową, włożyć kurczaka i grillować przez około 2 minut aż pokryje się brązowymi paskami, w międzyczasie skropić kurczaka sokiem z cytryny i/lub pomarańczy. Następnie przewrócić filety na drugą stronę i grillować przez minutę, skropić sokami. Na patelnię wrzucić śliwki i smażyć przez minutę. Wlać alkohol jeśli go używamy i chwilę odparować. Śliwki przemieszać, polać miodem wymieszanym z octem balsamicznym, chwilę podgrzewać, można kurczaka przewrócić na drugą stronę, odstawić z patelni. Podawać z kaszą i surówką."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ŁOSOŚ Z SOSEM ŚLIWKOWYM I SALSĄ MANGO",
                Image = "~/Images/Recipes/Dishes/5.jpg",
                SpicyValue = dishParameters[4][0],
                SaltyValue = dishParameters[4][1],
                BitterValue = dishParameters[4][2],
                SweetValue = dishParameters[4][3],
                MeatValue = dishParameters[4][4],
                SourValue = dishParameters[4][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,śliwki,mango,mięta,chili,cynamon,komosa ryżowa,ocet balsamiczny,oliwa,cukier trzcinowy,syrop klonowy,czosnek",
                Ingredients = "250 g filetu z łososia, 200 g śliwek, 1 mango, liście mięty, 1/4 łyżeczki chili w proszku, szczypta cynamonu, 1/2 szklanki komosy ryżowej (quinoa), ocet balsamiczny",
                Description = "Łosoś: Filet podzielić na 2 porcje. Odciąć skórkę. Doprawić solą, pieprzem, skropić 2 łyżkami soku z cytryny, 1 łyżeczką oliwy, 1 łyżeczką octu balsamicznego i 1 łyżeczką cukru lub syropu. Odstawić do zamarynowania, w międzyczasie 1-2 razy przewrócić na drugą stronę., Quinoa: Komosę wsypać do rondelka, wlać 1 szklankę wody, doprawić solą, pieprzem, dodać pół łyżeczki oliwy, pół łyżeczki soku z cytryny i pół ząbka czosnku. Przykryć i gotować pod przykryciem na minimalnym ogniu przez ok. 15-20 minut do czasu aż komosa wchłonie całą wodę., Sos śliwkowy: Do garnuszka lub małego rondelka włożyć 3/4 śliwek (bez pestek), dodać 4 łyżki octu balsamiczny, 2 łyżki cukru lub syropu klonowego, 1 łyżkę soku z cytryny, chili, cynamon, doprawić solą i pieprzem. Zmiksować ręcznym blenderem, zagotować, gotować jeszcze przez ok. 4 minuty, na koniec można jeszcze raz dokładnie zmiksować. Salsa mango ze śliwką: Mango obrać, pokroić w kosteczkę. 1/4 ilości śliwek wypestkować, pokroić w kosteczkę, wymieszać w miseczce z mango, z posiekaną miętą, 1 łyżką soku z cytryny lub limonki, łyżeczką oliwy oraz 1 łyżką cukru trzcinowego lub syropu. Rozgrzać patelnię grillować i położyć filety, grillować bez przewracania przez ok. 4 minuty, skropić resztą marynaty, po chwili przewrócić na drugą stronę i grillować jeszcze przez kolejne ok. 4 minuty."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA RYŻOWA Z DYNIĄ, MIELONYM MIĘSEM I POMIDORAMI",
                Image = "~/Images/Recipes/Dishes/6.jpg",
                SpicyValue = dishParameters[5][0],
                SaltyValue = dishParameters[5][1],
                BitterValue = dishParameters[5][2],
                SweetValue = dishParameters[5][3],
                MeatValue = dishParameters[5][4],
                SourValue = dishParameters[5][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "cebula cukrowa,czosnek,mielone mięso,kurkuma,kmin rzymski,cynamon,ostra papryka,słodka papryka,ryż,czerwona soczewica,dynia,pomidor,chili",
                Ingredients = "2 łyżki oleju roślinnego (użyłam kokosowego), 1 średnia cebula cukrowa, 2 ząbki czosnku, 350 g mielonego mięsa, przyprawy: 1 łyżeczka kurkumy, 1/2 łyżeczki kminu rzymskiego, po 1/3 łyżeczki cynamonu, ostrej papryki, czerwonej słodkiej papryki, 100 g ryżu, 1 szklanka czerwonej soczewicy, 3 szklanki bulionu, 2 szklanki obranej i pokrojonej w małą kostkę dyni, 600 g świeżych pomidorów lub 1 puszka pomidorów, kawałek świeżej chili",
                Description = "Piekarnik nagrzać do 180 stopni C. W żaroodpornym garnku na oleju zeszklić cebulę razem z rozgniecionym czosnkiem, dodać mielone mięso i dokładnie je obsmażyć. Doprawić solą i pieprzem, dodać przyprawy, chwilę podsmażyć. Dodać ryż i soczewicę, wymieszać i smażyć przez około 1-2 minuty. Wlać gorący bulion i zagotować. Dodać dynię, obrane i pokrojone w kosteczkę pomidory (bez nasion i soku z komór) oraz posiekaną chili. Wymieszać i zagotować. Garnek przykryć i wstawić do nagrzanego piekarnika. Piec przez około 20 minut do czasu aż ryż będzie miękki. Posypać kolendrą lub natką."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "LETNIE RISOTTO Z WARZYWAMI",
                Image = "~/Images/Recipes/Dishes/7.jpg",
                SpicyValue = dishParameters[6][0],
                SaltyValue = dishParameters[6][1],
                BitterValue = dishParameters[6][2],
                SweetValue = dishParameters[6][3],
                MeatValue = dishParameters[6][4],
                SourValue = dishParameters[6][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,cebula,czosnek,ryż,kurki,czerwona papryka,cukinia,białe wino,różowe wino,pomidor malinowy,gorgonzola,parmezan,tymianek,estragon,ostra papryka,kurkuma,kmin rzymski",
                Ingredients = "4 łyżki masła, 1 łyżka oliwy extra vergine, 1 cebula, 1 ząbek czosnku, 100 g ryżu do risotto (arborio), 100 g kurek, 1 podłużna czerwona papryka, 1 cukinia, ok. 300 g, 70 ml białego lub różowego wina, 1 duży pomidor malinowy, ok. 500 ml bulionu, 100 g sera gorgonzola, 4 łyżki tartego parmezanu lub grana padano, 1 łyżeczka suszonego tymianku, 1/2 łyżeczki suszonego estragonu, 1/3 łyżeczki ostrej papryki, 1/2 łyżeczki kurkumy, 1/3 łyżeczki mielonego kminu rzymskiego",
                Description = "W garnku roztopić 2 łyżki masła z 1 łyżką oliwy, dodać pokrojoną w kosteczki cebulę i zeszklić ją co chwilę mieszając. Dodać pokrojony na cienkie plasterki czosnek i jeszcze chwilę razem podsmażyć. Wsypać ryż oraz przyprawy i smażyć przez minutę mieszając. Dodać opłukane i osuszone kurki (nie trzeba ich kroić), pokrojoną w kostkę paprykę a po minucie smażenia dodać pokrojoną w kosteczkę cukinię. Smażyć wszystko przez około 2 minuty. Dodać wino i odparować, dodać obranego i pokrojonego w kosteczkę pomidora i smażyć jeszcze przez 1-2 minuty. Gotować risotto przez kilkanaście minut wlewając stopniowo bulion, po około pół szklanki, co chwilę zamieszać. Na koniec dodać rozdrobniony ser gorgonzola i wymieszać. Odstawić z ognia i odczekać 1 minutę. Dodać pozostałe 2 łyżki masła, parmezan, wymieszać i zaraz podawać."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "GRILLOWANE FILETY Z KURCZAKA PO MEKSYKAŃSKU",
                Image = "~/Images/Recipes/Dishes/8.jpg",
                SpicyValue = dishParameters[7][0],
                SaltyValue = dishParameters[7][1],
                BitterValue = dishParameters[7][2],
                SweetValue = dishParameters[7][3],
                MeatValue = dishParameters[7][4],
                SourValue = dishParameters[7][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,kolendra,słodka papryka,czosnek,oregano,tymianek,ostra papryka,ryż,czerwona cebula,koncentrat pomidorowy,kmin rzymski,czerwona fasola,awokado,pomidor,chili,kolendra",
                Ingredients = "500 g filetów z kurczaka, po 1 łyżeczce: mielonej kolendry, słodkiej papryki, suszonego czosnku, po 1/2 łyżeczki: suszonego oregano, tymianku, ostrej papryki, pieprzu białego mielonego, sok i skórka z 1/2 limonki, 2 łyżki oleju, 100 g ryżu, 1/2 łyżki oleju roślinnego, 1/2 czerwonej cebuli, 1 łyżka koncentratu pomidorowego, 1/4 łyżeczki mielonego kminu rzymskiego, 1 puszka (400 g) czerwonej fasoli, 1 awokado, 1 duży pomidor, 1/2 czerwonej cebuli, kawałek zielonej papryczki chili (może też być czerwona), liście świeżej kolendry, 1 łyżka soku z limonki",
                Description = "Filety z kurczaka opłukać, osuszyć i oczyścić z błonek i kostek. Pokroić na mniejsze filety wzdłuż i w poprzek, rozbić na cieńsze filety. Doprawić solą a następnie natrzeć mieszanką przypraw, skropić sokiem i natrzeć skórką z limonki, obtoczyć w oleju. Odłożyć do zamarynowania na minimum 30 minut (można na całą noc włożyć do lodówki). Kłaść na rozgrzaną patelnię grillową i grillować bez ruszania mięsa przez około 3 minuty, aż mięso wysmaży się do połowy filetów. Wówczas przewrócić na drugą stronę i powtórzyć grillowanie przez około 2,5 minuty. Zdjąć z patelni. Smażona czerwona fasola: na patelni rozgrzać olej i zeszklić drobno posiekaną cebulę. Dodać koncentrat pomidorowy i kmin rzymski, chwilę podsmażyć, następnie dodać odsączoną fasolę i podsmażyć wszystko przez ok. 2 minuty. Można wymieszać z ugotowanym ryżem lub podawać oddzielnie. Salsa: przygotować warzywa (awokado obrać i pokroić w kostkę; pomidora sparzyć wrzątkiem, obrać ze skórki i pokroić w kostkę; cebulę drobno posiekać; chili oczyścić z pestek i drobno posiekać) i wymieszać wszystkie składniki salsy w większej salaterce."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "PAPRYKA FASZEROWANA PO MEKSYKAŃSKU",
                Image = "~/Images/Recipes/Dishes/9.jpg",
                SpicyValue = dishParameters[8][0],
                SaltyValue = dishParameters[8][1],
                BitterValue = dishParameters[8][2],
                SweetValue = dishParameters[8][3],
                MeatValue = dishParameters[8][4],
                SourValue = dishParameters[8][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "cebula cukrowa,czosnek,chili,ocet jabłkowy,kmin rzymski,cynamon,oregano,oliwa,papryka,wołowina,passata pomidorowa,sos sojowy,ryż,czerwona fasola,kukurydza,cheddar,mozzarella",
                Ingredients = "1 cebula cukrowa, 3 ząbki czosnku, 1 papryczka chili, 1/4 szklanki octu jabłkowego, 2 łyżeczki mielonego kminu rzymskiego, 2 łyżeczki mielonego cynamonu, 1 łyżeczka suszonego oregano, 1/2 łyżeczki cukru, 1 łyżka oliwy, 6 papryk, 500 g mielonej wołowiny (np. antrykotu), 1 szklanka (250 ml) passaty pomidorowej, 2 szklanki (500 ml) bulionu wołowego, 1 łyżka sosu sojowego, 3/4 szklanki (150 g) ryżu Arborio, 1 mała puszka (1/2 szklanki) czerwonej lub czarnej fasoli, 1 świeża kukurydza (lub mała puszka), 100 g tartego sera (np. cheddar, manchego, żółta mozzarella)",
                Description = "Przygotować marynatę: cebulę i czosnek obrać, papryczkę chili przeciąć wzdłuż na pół i łyżeczką oczyścić z nasion i jasnych włókien. Pokroić na mniejsze części i razem z pozostałymi składniki marynaty zmiksować wszystko na pastę (w małym malakserze lub blenderze). Mięso wymieszać z marynatą i zostawić do ocieplenia (lub dłużej, np. na całą noc w lodówce). Ściąć górę papryk, środek wydrążyć, oczyścić i posolić.  Nożem obkroić ziarna ze świeżej kukurydzy. Nastawić piekarnik na 190 st. C. Na dużej patelni (o średnicy min. 28 cm) rozgrzać oliwę i na dużym ogniu równomiernie obsmażyć zamarynowane mięso aż zmieni kolor na szary. Doprawić solą i pieprzem. Do podsmażonego mięsa dodać passatę pomidorową, wymieszać i zagotować. Dodać gorący bulion i sos sojowy a następnie ryż (surowy), odcedzoną fasolę i ziarna kukurydzy. Wymieszać i zagotować, gotować jeszcze przez 3 minuty mieszając co jakiś czas. Łyżką wazową ostrożnie nałożyć gorący farsz do papryk. Papryki przykryć odkrojoną częścią i wstawić do piekarnika na 45 minut. Po wyjęciu z piekarnika papryki otworzyć i posypać tartym serem. Podawać posypane listkami świeżej kolendry, opcjonalnie z jogurtem naturalnym lub/i guacamole."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "GOŁĄBKI Z GRILLOWANEGO BAKŁAŻANA",
                Image = "~/Images/Recipes/Dishes/10.jpg",
                SpicyValue = dishParameters[9][0],
                SaltyValue = dishParameters[9][1],
                BitterValue = dishParameters[9][2],
                SweetValue = dishParameters[9][3],
                MeatValue = dishParameters[9][4],
                SourValue = dishParameters[9][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "bakłażan,indyk,cynamon,cebula,czosnek,chili,pietruszka,parmezan,oliwa,pomidor,białe wino,ogórek gruntowy,kmin rzymski,kolendra,mięta,jogurt naturalny,jogurt grecki,majonez",
                Ingredients = "2 bakłażany, 500 g mielonego mięsa (np. łopatki, szynki lub piersi indyka), sól i pieprz, szczypta cynamonu, 1 łyżka masła, 1/2 cebuli, 2 ząbki czosnku, 1/2 papryczki chili, bez pestek, 1 łyżka posiekanej natki pietruszki, 1/3 szklanki startego parmezanu lub innego twardego sera, 2 łyżki oliwy extra vergine, 2 pomidory (lub 200 g pomidorów z puszki lub passaty), 4 łyżki białego wina (opcjonalnie), sól, pieprz, cukier",
                Description = "Bakłażany pokroić wzdłuż na długie cienkie plastry o grubości około 3 mm, oprószyć solą (około 1 łyżeczki) i zostawić w misce na około 20 minut. Następnie opłukać z soli pod bieżącą chłodną wodą i osuszyć. Układać partiami na mocno rozgrzanej patelni grillowej (lub zwykłej patelni, można też piec w piekarniku), skrapiać oliwą i grillować aż bakłażan nieco zmięknie i pojawią się ciemne paski*, powtórzyć z drugą stroną bakłażana. Zdjąć z patelni i ostudzić. Mięso mielone włożyć do miski, doprawić solą, pieprzem i cynamonem. Na patelni roztopić masło i dodać drobno posiekane: cebulę, czosnek, chili i natkę pietruszki (składniki można rozdrobnić w melakserze lub pojemniku rozdrabniacza). Podsmażać składniki przez około 5 minut aż lekko się zrumienią. Dodać do mięsa razem z serem i wszystko dokładnie wymieszać. Rozdzielić nadzienie na plastry bakłażana i zawinąć w roladkę. Piekarnik nagrzać do 180 stopni C. Sos pomidorowy: świeże pomidory obrać, pokroić na mniejsze kawałki, wykroić szypułkę, usunąć nasiona z komór. Miąższ pokroić w kosteczkę, wrzucić do rondelka, dodać wino jeśli używamy, doprawić solą i pieprzem i gotować przez około 7 minut aż sos zgęstnieje. Na koniec zmiksować blenderem i wlać do naczynia żaroodpornego. Pomidory z puszki wystarczy wyłożyć do garnka, dodać przyprawy i gotować przez ok. 5 minut. Do naczynia z sosem włożyć roladki z bakłażana i wstawić do piekarnika, piec przez ok. 30 minut."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "AROMATYCZNE BIRYANI Z SOCZEWICĄ, MARCHEWKĄ I POMIDORAMI",
                Image = "~/Images/Recipes/Dishes/11.jpg",
                SpicyValue = dishParameters[10][0],
                SaltyValue = dishParameters[10][1],
                BitterValue = dishParameters[10][2],
                SweetValue = dishParameters[10][3],
                MeatValue = dishParameters[10][4],
                SourValue = dishParameters[10][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,cebula,czosnek,por,indyk,słodka papryka,ostra papryka,kolendra,kopr włoski,marchewka,pietruszka,ryż,czerwona soczewica,pomidor",
                Ingredients = "2 łyżki oliwy extra vergine, 1/2 cebuli, 3 ząbki czosnku, 1/3 pora, 500 g zmielonego udźca lub filetu z indyka, 1 łyżeczka słodkiej papryki w proszku, 1/2 łyżeczki ostrej papryki, 1 łyżeczka mielonej kolendry, 1 i 1/2 łyżeczki nasion kopru włoskiego, 2 średnie marchewki, 1 pietruszka, 200 g ryżu długoziarnistego (np. basmati), 1 szklanka czerwonej soczewicy, 1 puszka (400 g) pomidorów, 1/2 szklanki ajwaru/ajvaru - opcjonalnie, kilka gałązek natki i świeża kolendra",
                Description = "W dużym żaroodpornym dużym garnku na 1 łyżce oliwy podsmażyć cebulę i pokrojonego pora. Pod koniec dodać starty czosnek. Przesunąć warzywa na bok, w wolne miejsce wlać drugą łyżkę oliwy, włożyć mięso i dokładnie je obsmażyć. W międzyczasie dodać słodką i ostrą paprykę, kmin rzymski i koper włoski. Na koniec doprawić solą i pieprzem. Piekarnik nagrzać do 180 stopni C. Wymieszać składniki w garnku, dodać obraną i pokrojoną na cienkie plasterki marchewkę oraz pietruszkę i smażyć przez ok. 5 minut, co chwilę mieszając. Wlać 3 szklanki wrzącej wody i gotować pod przykryciem przez ok. 10 minut. Wsypać ryż, soczewicę i zagotować. Dodać zmiksowane pomidory z puszki, ajwar jeśli go używamy, posiekaną natkę pietruszki i pół łyżeczki cukru, wymieszać, zagotować. Przykryć pokrywą (lub szczelnie folią aluminiową) i wstawić do piekarnika na 20 minut. Można też dokończyć gotowanie potrawy na gazie, bez wstawiania do piekarnika. Wyjąć garnek i zostawić potrawę pod przykryciem na około 5 minut. Otworzyć, posypać kolendrą."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "FILETY DORSZA SMAŻONE W CURRY",
                Image = "~/Images/Recipes/Dishes/12.jpg",
                SpicyValue = dishParameters[11][0],
                SaltyValue = dishParameters[11][1],
                BitterValue = dishParameters[11][2],
                SweetValue = dishParameters[11][3],
                MeatValue = dishParameters[11][4],
                SourValue = dishParameters[11][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "dorsz,curry,ziemniaki,pieczarki,oregano,oliwa",
                Ingredients = "4 filety dorsza bałtyckiego ze skórką, świeże lub mrożone, sól i opcjonalnie - biały pieprz, 3 łyżki mąki pszennej, 1 czubata łyżeczka przyprawy curry w proszku, masło klarowane do smażenia, 4 ziemniaki, 200 g pieczarek, sól i pieprz, 1/2 łyżeczki suszonego oregano, 1 łyżka oliwy extra vergine",
                Description = "Ryba: Jeśli używamy mrożonych filetów, należy je dokładnie rozmrozić a następnie bardzo dokładnie osuszyć z wody papierowymi ręcznikami. Na talerzu wymieszać mąkę z przyprawą curry. Osuszone filety doprawić solą (i opcjonalnie białym pieprzem). Obtoczyć w mieszance z mąki i strzepnąć jej nadmiar. W międzyczasie przygotować sos pomidorowy. Rozgrzać patelnię, następnie włożyć 3 łyżki masła klarowanego i smażyć po 2 filety jednocześnie skórką do dołu przez około 4,5 minuty na średnim ogniu, następnie przewrócić na drugą stronę i smażyć jeszcze przez około 1,5 minuty. Usmażoną rybę odkładać na ręczniki papierowe. Powtórzyć z resztą ryby, uprzednio wycierając ostrożnie patelnię ręcznikiem papierowym i dając nowy tłuszcz do smażenia. Ziemniaki i pieczarki z pieca: Piekarnik nagrzać do 240 stopni C. Ziemniaki obrać i pokroić w kostkę (do czasu pieczenia trzymać w zimnej wodzie aby nie ściemniały). Pieczarki oczyścić szczoteczką i pokroić na mniejsze kawałki. Ziemniaki osuszyć ręcznikiem i razem z pieczarkami wyłożyć na większą blaszkę, doprawić solą, pieprzem, oregano i skropić oliwą. Wymieszać dłońmi i rozłożyć po całej blaszce. Wstawić do piekarnika i piec przez około 20 minut, do czasu aż ziemniaki będą miękkie i lekko zrumienione, w połowie pieczenia raz przemieszać. Ziemniaki z pieczarkami wymieszać z porwaną bazylią i podawać razem z rybą oraz sosem pomidorowym."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ŁOSOŚ W CIEŚCIE FRANCUSKIM",
                Image = "~/Images/Recipes/Dishes/13.jpg",
                SpicyValue = dishParameters[12][0],
                SaltyValue = dishParameters[12][1],
                BitterValue = dishParameters[12][2],
                SweetValue = dishParameters[12][3],
                MeatValue = dishParameters[12][4],
                SourValue = dishParameters[12][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,ciasto francuskie,czosnek,oliwa,sos sojowy,suszone pomidory,migdały,bazylia",
                Ingredients = "600 g filetów łososia, 250 g gotowego ciasta francuskiego, sól i pieprz, 2 ząbki czosnku, 3 łyżki oliwy extra vergine, 1 łyżka sosu sojowego, 1 łyżka soku z cytryny, 9 kawałków suszonych pomidorów ze słoika, w oleju, 1 ząbek czosnku, 3 łyżki migdałów pokrojonych w słupki, listki z 1 pęczka (doniczki) bazylii, 1 łyżka oliwy extra vergine, sól i pieprz",
                Description = "Łosoś: Odciąć skórkę z łososia i podzielić go na paski około 5 x 10 cm. Włożyć do miski, doprawić solą, pieprzem oraz wymieszać z resztą składników marynaty: cienko pokrojonym czosnkiem, oliwą, sosem sojowym i sokiem z cytryny, odstawić (na czas przygotowania dania lub na 1 godzinę jeśli mamy czas). Pesto: do pojemnika rozdrabniacza włożyć suszone pomidory, czosnek, słupki migdałów, listki bazylii, oliwę, rozdrobnić na drobne kawałeczki, można też składniki drobno posiekać na desce. Doprawić solą i pieprzem. Piekarnik nagrzać do 190 stopni C. Grube na 1 cm ciasto rozwałkować na stolnicy na około 20 x 30 cm placek o grubości ok. 2 mm, cienkiego ciasta nie trzeba już rozwałkowywać. Filety z łososia obłożyć z jednej strony połową pesto, położyć na cieście posmarowaną stroną do dołu, wierzch obłożyć resztą pesto. Łososia ułożyć grubą warstwą (cieńsze kawałki filetów mogą nachodzić na siebie). Zawinąć ciasto na filety, docisnąć i odkroić zbędne ciasto. Roladkę posmarować roztrzepanym jajkiem i pokroić na 6 części. Położyć na blaszce i wstawić do piekarnika. Piec przez ok. 20 minut. Wyjąć z piekarnika i zdjąć z blaszki aby łosoś się nie wysuszał."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ŁOSOŚ SMAŻONY W SEZAMIE",
                Image = "~/Images/Recipes/Dishes/14.jpg",
                SpicyValue = dishParameters[13][0],
                SaltyValue = dishParameters[13][1],
                BitterValue = dishParameters[13][2],
                SweetValue = dishParameters[13][3],
                MeatValue = dishParameters[13][4],
                SourValue = dishParameters[13][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,makaron gryczany,makaron ryżowy,biały sezam,czarny sezam,sos sojowy,miód,imbir,biała rzodkiewka,chili,ocet ryżowy,cukier trzcinowy",
                Ingredients = "2 filety łososia bez skóry, każdy po około 150 g, 100 g makaronu gryczanego soba lub makaronu ryżowego, 2 łyżki białego sezamu, 2 łyżki czarnego sezamu, sos sojowy, sok z limonki, cukier lub miód, 1 łyżeczka mielonego imbiru w proszku, starta biała długa rzodkiewka, około 1 szklanka, kilka plasterków zielonej papryczki chili, 1 łyżka soku z limonki, 1 łyżka octu ryżowego, 1 łyżeczka cukru trzcinowego",
                Description = "Łososia zamarynować w mieszance sosu sojowego (2 łyżki), soku z limonki (2 łyżki), cukru lub miodu (1 łyżeczka), 1 łyżeczce mielonego imbiru, szczypcie soli lub łyżeczce sosu rybnego i szczypcie pieprzu. Odstawić na około 1 godzinę lub dłużej jeśli mamy czas. Ugotować makaron zgodnie z instrukcją na opakowaniu. Wyjąć łososia z marynaty i delikatnie osuszyć. Resztę marynaty (jeśli taka pozostała) wlać do rondelka, dodać 3 dodatkowe łyżki sosu sojowego, 1 łyżeczkę cukru lub miodu i zagotować. Gotować przez 1 - 2 minuty aż sos zgęstnieje, odstawić. Dodać ugotowany i odcedzony makaron, wymieszać, odstawić. Łososia obtoczyć w mieszance jasnego i czarnego sezamu i położyć na rozgrzanej patelni z nieprzywierającą powłoką (smażymy bez użycia tłuszczu). Smażyć przez około 3 minuty na umiarkowanym ogniu, uważając aby ziarna tylko się lekko zrumieniły a nie spaliły, przewrócić na drugą stronę i smażyć przez kolejne około 2 minuty, obsmażyć jeszcze po minucie z dwóch pozostałych stron. Łosoś nie może być przesuszony, mięso ma być delikatne i miękkie. Czas smażenia zależy od grubości filetu i może się różnić. Makaron podgrzać jeśli ostygł i podawać do łososia z surówką z rzodkiewki. Surówka: rzodkiew zetrzeć na tarce lub pokroić na cienkie plasterki, posolić szczyptą soli i odstawić na kilkanaście minut. Odcisnąć z soku, włożyć do miski, dodać chili, sok z limonki, ocet, cukier, wymieszać i podawać do łososia."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "BURGERY Z ŁOSOSIA, SZPINAKU I RYŻU",
                Image = "~/Images/Recipes/Dishes/15.jpg",
                SpicyValue = dishParameters[14][0],
                SaltyValue = dishParameters[14][1],
                BitterValue = dishParameters[14][2],
                SweetValue = dishParameters[14][3],
                MeatValue = dishParameters[14][4],
                SourValue = dishParameters[14][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,ryż,szpinak,jajko,oregano,tymianek,natka pietruszki,gałka muszkatołowa,oliwa,jogurt grecki,szczypiorek,czosnek",
                Ingredients = "300 g filetów łososia (surowych lub pieczonych/zgrillowanych), 100 g (1 torebka) ryżu, ugotowanego na miękko, 150 g szpinaku, 1 jajko, 1 łyżeczka suszonego oregano lub tymianku, 2 łyżki posiekanych świeżych ziół np. tymianku lub oregano lub natka pietruszki, szczypta gałki muszkatołowej, 2 łyżki oliwy extra, 330 g jogurtu greckiego, sól morska i świeżo, zmielony czarny pieprz, 1/2 łyżeczki skórki z cytryny i 2 łyżki wyciśniętego soku, pęczek szczypiorku, posiekanego, 1/2 ząbka czosnku, startego na tarce lub rozgniecionego",
                Description = "Łososia rozdrobnić, sprawdzić czy nie ma ości, włożyć do miski. Dodać ugotowany i odcedzony ryż. Szpinak opłukać, włożyć na patelnię i podgrzewać przez około 1 minutę aż zwiędnie, co chwilę mieszając. Zdjąć z patelni i odcisnąć. Drobno posiekać i dodać do miski z łososiem. Wszystko doprawić solą i pieprzem, dodać jajko, suszone i świeże zioła lub natkę, gałkę muszkatołową oraz oliwę. Wymieszać, uformować 8 kotlecików i ułożyć je na tacy. Do tej samej miski wlać oliwę, dłońmi smarować kotleciki oliwą i układać je na patelni. Smażyć na średnim ogniu przez około 2 minuty z każdej strony (z surowego łososia) lub po około 1,5 minuty (z łososia wcześniej upieczonego/zgrillowanego). Podawać na sałacie z jogurtem cytrynowym."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "KURCZAK W MARYNACIE JOGURTOWEJ ZAPIEKANY Z MOZZARELLĄ I POMIDORKAMI",
                Image = "~/Images/Recipes/Dishes/16.jpg",
                SpicyValue = dishParameters[15][0],
                SaltyValue = dishParameters[15][1],
                BitterValue = dishParameters[15][2],
                SweetValue = dishParameters[15][3],
                MeatValue = dishParameters[15][4],
                SourValue = dishParameters[15][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,czerwona papryka,jogurt grecki,oliwa,miód,mozzarella,pomidorki koktajlowe,oregano",
                Ingredients = "2 pojedyncze piersi kurczaka, sól morska, 2 łyżeczki czerwonej papryki w proszku (opcjonalnie pół na pół z wędzoną), 1 łyżka mąki pszennej, 300 g jogurtu bałkańskiego (lub greckiego), 1 łyżka oliwy z oliwek, 1 łyżka miodu, 125 g kulka mozzarelli (lub 100 - 200 g roladki koziej), 350 g pomidorków koktajlowych, 1 łyżeczka suszonego oregano, 1 łyżka oliwy extra vergine",
                Description = "Piersi kurczaka oczyścić z kostek i błonek, przekroić na 2 pojedyncze piersi. Każdą pierś przekroić w poprzek na dwie połówki. Grubszą połówkę przekroić wzdłuż na 2 cieńsze filety. Cienką połówkę pozostawić bez krojenia. Z każdej piersi powinniśmy otrzymać 3 cienkie fileciki. Oprószyć je solą morską i czerwoną papryką, dodać oliwę i wysmarować dokładnie dłońmi. Oprószyć w mące pszennej. Połączyć jogurt z oliwą, miodem i szczyptą soli. Kurczaka włożyć do plastikowej miski, dodać jogurt z dodatkami i delikatnie wymieszać. Odstawić na blat kuchenny na minimum godzinę, najlepiej 2 - 3 godziny. Piekarnik nagrzać do 210 stopni. W piekarniku nagrzać również blaszkę do zapiekania. Mozzarellę pokroić na 6 plasterków, oprószyć solą morską. Pomidorki opłukać i osuszyć, położyć na talerz, doprawić solą, pieprzem, 1 łyżeczką cukru, suszonym oregano i oliwą extra vergine. Delikatnie wymieszać. Na rozgrzaną blaszkę położyć piersi kurczaka razem z marynatą, przykryć mozzarellą. Wyłożyć pomidorki i wstawić do piekarnika. Piec przez 15 minut, na 5 minut przed końcem można ustawić funkcję grilla w piekarniku. Podawać z jogurtem greckim, posypując szczypiorkiem i papryką w proszku. Z bagietką lub ziemniakami dla chętnych."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "BAKŁAŻANY ZAPIEKANE Z MIĘSEM, KASZĄ GRYCZANĄ I JOGURTEM GRECKIM",
                Image = "~/Images/Recipes/Dishes/17.jpg",
                SpicyValue = dishParameters[16][0],
                SaltyValue = dishParameters[16][1],
                BitterValue = dishParameters[16][2],
                SweetValue = dishParameters[16][3],
                MeatValue = dishParameters[16][4],
                SourValue = dishParameters[16][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "bakłażań,oliwa,kasza gryczana,cebula,czosnek,mielone mięso,pomidor,koncentrat pomidorowy,cukier,oregano,tymianek,chili,natka pietruszki,cynamon",
                Ingredients = "3 bakłażany (najlepiej niezbyt duże) sól, pieprz, 2 łyżki oliwy extra vergine, 2 łyżki oliwy + 2 łyżki oliwy extra vergine, 50 g kaszy gryczanej, 1 cebula, 1 ząbek czosnku, 300 g chudego mielonego mięsa dobrej jakości (np. cielęcina), 1/4 szklanki wina + dodatkowo 4 łyżki, 400 g pomidorów z puszki (obranych, pokrojonych), 1 łyżka koncentratu pomidorowego, 1/2 łyżeczki cukru, przyprawy: sól, pieprz, po 1 łyżeczce suszonego oregano i tymianku, po 1/3 łyżeczki cynamonu i chili, 1 łyżka natki pietruszki, ewentualnie świeże zioła, 180 g jogurtu greckiego, 1 łyżeczka musztardy, 1 jajko, 70 g sera feta, zmielony kmin rzymski (opcjonalnie)",
                Description = "Bakłażany: Piekarnik nagrzać do 180 stopni. Bakłażany przeciąć wzdłuż na pół, miąższ ponacinać nożem w kratkę nie naruszając skórki, posypać solą, pieprzem, wysmarować oliwą extra vergine. Ułożyć na blaszce rozcięciem do góry i piec przez około 25 minut. Farsz z mięsa i kaszy gryczanej: Ugotować kaszę gryczaną w osolonej wodzie. Na dużej patelni rozgrzać 2 łyżki oliwy, zeszklić posiekaną cebulę (7 minut), pod koniec dodać posiekany czosnek. Dodać mielone mięso i obsmażyć dokładnie z każdej strony przez około 5 minut, co chwilę mieszając. Wlać 1/4 szklanki wina i odparować (przez około 2 - 3 minuty). Dodać pomidory, doprawić solą, pieprzem, zagotować. Dodać koncentrat pomidorowy, cukier i gotować wszystko przez 10 minut. Wyjąć bakłażany (nie wyłączać piekarnika) i łyżeczką wybrać miąższ pozostawiając 1 cm brzeg. Wyjęty miąższ posiekać i dodać do gotującego się farszu. Dodać wszystkie przyprawy: oregano, tymianek, cynamon, chili, natkę pietruszki i ewentualnie świeże zioła. Smażyć przez 5 minut, następnie dodać dobrze odsączoną kaszę gryczaną i smażyć przez 2 minuty, na koniec doprawić w razie potrzeby solą i pieprzem. Sos jogurtowy: jajko roztrzepać w głębokim talerzu, dodać jogurt wymieszany z musztardą i rozdrobnioną fetę. Delikatnie wymieszać. Spód bakłażanów posmarować oliwą i ułożyć na blaszce. Nałożyć farsz z patelni, skropić winem, polać masą jogurtową, posypać kminem rzymskim i udekorować tymiankiem. Wstawić do nagrzanego piekarnika i piec przez 30 minut."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "MOUSSAKA",
                Image = "~/Images/Recipes/Dishes/18.jpg",
                SpicyValue = dishParameters[17][0],
                SaltyValue = dishParameters[17][1],
                BitterValue = dishParameters[17][2],
                SweetValue = dishParameters[17][3],
                MeatValue = dishParameters[17][4],
                SourValue = dishParameters[17][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "bakłażan,oliwa,cebula,czosnek,mielone mięso,białe wino,pomidor,natka pietruszki,cynamon,chili,oregano",
                Ingredients = "700 g bakłażana (2 sztuki), 4 łyżki oliwy extra vergine, 1 łyżka oleju roślinnego, 1 cebula, 1 ząbek czosnku, 500 g chudego mielonego mięsa (cielęciny, wołowiny lub jagnięciny lub mieszanego), 1/3 szklanki białego wina, 1 puszka pomidorów (obranych i pokrojonych) w gęstym sosie pomidorowym + ewentualnie 1 łyżka koncentratu pomidorowego, 1 łyżka posiekanej natki pietruszki, 1/2 łyżeczki mielonego cynamonu, szczypta chili, 1 łyżeczka suszonego oregano, 1/2 łyżeczki cukru, sól morska i świeżo zmielony czarny pieprz, 30 g masła, 2 płaskie łyżki mąki (25 g), 300 ml mleka, sól morska, szczypta gałki muszkatołowej, 1/2 szklanki tartego parmezanu",
                Description = "Bakłażany: Nagrzać piekarnik z funkcją grilla na średnio dużą moc. Bakłażana pokroić na półcentymetrowe plasterki ułożyć na dużej blaszce do pieczenia posmarowanej 2 łyżkami oliwy (plasterki mogą częściowo na siebie nachodzić). Oprószyć solą i skropić resztą oliwy, wstawić na górną półkę piekarnika i grillować przez około 6 - 7 minut lub do czasu aż bakłażany będą miękkie i lekko zrumienione, przewrócić na drugą stronę i grillować przez kolejne 6 - 7 minut. Zdjąć z blaszki i przełożyć do miski. Sos mięsno-pomidorowy: Na dużą patelnię wlać olej, dodać drobno posiekaną cebulę oraz czosnek, zeszklić na umiarkowanym ogniu przez około 8 minut, nie rumienić. Zwiększyć ogień, dodać zmielone mięso i mieszając dokładnie obsmażyć przez około 5 minut. Wlać wino a po minucie dodać resztę składników sosu: pomidory, koncentrat jeśli używamy, natkę pietruszki, cynamon, chili, oregano, cukier. Doprawić solą i pieprzem, wymieszać i zagotować. Przykryć, zmniejszyć ogień i dusić przez około 40 minut od czasu do czasu mieszając. Sos beszamelowy: Roztopić masło na patelni lub w garnku, dodać mąkę i smażyć przez około 2 minuty na umiarkowanym ogniu ciągle mieszając. Stopniowo wlewać mleko cały czas mieszając aż sos zgęstnieje i będzie gładki. Doprawić solą, gałką muszkatołową, dodać połowę startego sera, wymieszać i podgrzać aż ser się rozpuści, odstawić z ognia.Piekarnik nagrzać do 180 stopni. Żaroodporne naczynie o pojemności około 2l posmarować masłem lub oliwą. Bakłażany podzielić na 3 części, na dnie rozłożyć pierwszą część, przykryć połową sosu mięsno-pomidorowego, ułożyć drugą warstwę bakłażana i przykryć resztą sosu mięsno-pomidorowego. Położyć pozostałe plastry bakłażana i polać sosem beszamelowym. Posypać resztą sera i wstawić do nagrzanego piekarnika na 35 minut."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA Z ŁOSOSIEM, TARTĄ CUKINIĄ I PLASTERKAMI ZIEMNIAKÓW",
                Image = "~/Images/Recipes/Dishes/19.jpg",
                SpicyValue = dishParameters[18][0],
                SaltyValue = dishParameters[18][1],
                BitterValue = dishParameters[18][2],
                SweetValue = dishParameters[18][3],
                MeatValue = dishParameters[18][4],
                SourValue = dishParameters[18][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "ziemniaki,łosoś,cukinia,śmietanka,camembert,jajko,parmezan,oregano",
                Ingredients = "800 g ziemniaków, 300 g łososia, surowego lub grillowanego, 600 g cukinii (może być mieszana żółta + zielona), 2 łyżki masła, 6 łyżek śmietanki kremowej 30%, 100 g sera camembert, 1 pełna łyżka mąki ziemniaczanej, 2 surowe żółtka (lub 1 całe jajko), 20 - 30 g tartego parmezanu, świeże oregano, sól i czarny pieprz (młotkowany lub świeżo zmielony)",
                Description = "Piekarnik nagrzać do 180 stopni. Formę o wymiarach około 18 x 29 cm posmarować 1 łyżką masła. Ziemniaki oskrobać lub obrać, opłukać i pokroić na cieniutkie plasterki. Włożyć do garnka, przepłukać, wlać świeżej zimnej wody, posolić i zagotować. Gotować jeszcze przez około 5 minut, aż ziemniaki będą miękkie, ale nie będą się rozpadać. Odcedzić i wyłożyć na tacę. Łososia obrać ze skórki, usunąć ości, opłukać, osuszyć i pokroić na kawałeczki. Można użyć łososia już zgrillowanego lub podgotowanego na parze, ale może być też surowy. Cukinię zetrzeć na tarce o dużych oczkach. Na dużej patelni roztopić 1 łyżkę masła, dodać cukinię i smażyć na większym ogniu przez około 2 minuty, co chwilę mieszając. Doprawić solą, czarnym pieprzem, dodać śmietankę, pokrojony na kawałeczki ser i wymieszać. Odlać około 1/2 szklanki soku z cukinii i wymieszać go z mąką ziemniaczaną. Wlać z powrotem na patelnię, wymieszać i delikatnie zagotować. Odstawić patelnię z ognia i dodać żółtka, od razu wymieszać (żółtka mają pozostać płynne a cukinię ma pokryć średnio gęsty sos). Ziemniaki podzielić na 3 części. Ułożyć pierwszą warstwę ziemniaków, jeden obok drugiego, posypać pieprzem, wyłożyć połowę cukinii, przykryć ziemniakami, znów posypać pieprzem i wyłożyć cukinię, rozłożyć kawałeczki łososia, przykryć ziemniakami, zetrzeć parmezan i wstawić do piekarnika. Piec przez 10 minut (grzanie góra i dół) + 5 minut pod grillem (lub 5 minut jak poprzednio), posypać świeżym oregano."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "PAPRYKI ZAPIEKANE Z MIELONYM KURCZAKIEM, RYŻEM I SOSEM POMIDOROWYM",
                Image = "~/Images/Recipes/Dishes/20.jpg",
                SpicyValue = dishParameters[19][0],
                SaltyValue = dishParameters[19][1],
                BitterValue = dishParameters[19][2],
                SweetValue = dishParameters[19][3],
                MeatValue = dishParameters[19][4],
                SourValue = dishParameters[19][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "ryż,czerwona papryka,oliwa,kurczak,cebula,czosnek,jajko,oregano,tymianek,natka pietruszki,pomidor,białe wino",
                Ingredients = "50 g ryżu (pół torebki), 2 czerwone papryki, 4 łyżki oliwy extra vergine, 200 g piersi kurczaka (1 sztuka) lub pół piersi + 100 g posiekanych krewetek, 1/4 cebuli, drobniutko posiekanej, 1 ząbek czosnku, drobno starty, 1/2 surowego jajka, 1 łyżeczka suszonego oregano, 1/2 łyżeczki suszonego tymianku, 1 łyżka drobno posiekanej natki pietruszki, 4 łyżki posiekanych obranych pomidorów z puszki (lub świeżych pomidorów, pokrojonych w kosteczkę, bez soku i nasion), 4 łyżki białego wina",
                Description = "Ugotować ryż (najlepiej całą torebkę) w osolonej wodzie, odłożyć potrzebną ilość. Paprykę przekroić wzdłuż na 2 części. Każdą połówkę oczyścić, wysmarować 1 łyżką oliwy extra vergine, doprawić solą i pieprzem. Piekarnik nagrzać do 180 stopni. Pierś kurczaka zmielić lub drobno posiekać. Włożyć do miski (zamiast kurczaka - mielone mięso lub posiekane krewetki), dodać ryż, cebulę, czosnek, jajko, połowę suszonego oregano, cały tymianek, natkę pietruszki, 1 łyżkę oliwy extra vergine. Doprawić solą i świeżo zmielonym pieprzem, wymieszać. Farsz włożyć w połówki papryki, ułożyć w naczyniu żaroodpornym. Nałożyć po 1 łyżce pomidorów, polać winem i resztą oliwy. Doprawić solą, pieprzem oraz resztą oregano. Wstawić do piekarnika i piec przez 45 minut."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA Z ŁOSOSIEM I BROKUŁAMI POD PLASTERKAMI ZRUMIENIONYCH ZIEMNIAKÓW",
                Image = "~/Images/Recipes/Dishes/21.jpg",
                SpicyValue = dishParameters[20][0],
                SaltyValue = dishParameters[20][1],
                BitterValue = dishParameters[20][2],
                SweetValue = dishParameters[20][3],
                MeatValue = dishParameters[20][4],
                SourValue = dishParameters[20][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "łosoś,mleko,ziemniaki,por,brokuł,kapary,krewetki,oliwa",
                Ingredients = "800 g filetu z łososia, 600 ml mleka, 800 g ziemniaków, 40 g masła, 200 g porów (białe i jasno zielone części), 40 g mąki pszennej, 200 g brokuła, 1 łyżka kaparów, 200 g krewetek (lub więcej łososia), 2 łyżeczki soku z cytryny, 2 - 3 łyżki roztopionego masła lub oliwy extra",
                Description = "Z łososia odciąć skórę, opłukać i osuszyć papierowym ręcznikiem. Pesetą wyjąć ości, oprószyć delikatnie solą. Do garnka wlać mleko i włożyć łososia. Zagotować, przewrócić na drugą stronę i zaraz odstawić z ognia. Rybę wyjąć z mleka, położyć na talerzyku i pokroić na mniejsze kawałki. Mleko zachować. Piekarnik nagrzać do 210 stopni. Ziemniaki obrać i pokroić na cienkie plasterki. Włożyć do garnka z chłodną wodą, doprawić solą i zagotować. Gotować przez około 3 - 4 minuty, następnie odcedzić na sicie. Na patelni roztopić masło, dodać pokrojone na plasterki pory i dusić na małym ogniu pod przykryciem przez około 3 - 4 minuty. Następnie wsypać mąkę i wymieszać. Wlać mleko (stopniowo, po pół szklanki) delikatnie mieszając. Gotować bez przykrycia na małym ogniu przez około 10 minut, w razie potrzeby dodać więcej mleka lub wody, gdyby sos stał się zbyt gęsty. Dodać brokuła podzielonego na małe różyczki, odsączone kapary oraz krewetki jeśli ich używamy (obrać wcześniej z pancerzy, oderwać ogonki i nadkroić w najgrubszej części). Zawartość patelni doprawić solą morską, świeżo zmielonym czarnym pieprzem oraz sokiem z cytryny. Delikatnie wymieszać, po minucie gotowania odstawić z ognia. Dużą żaroodporną formę posmarować kawałkiem masła, na dnie rozłożyć łososia, wyłożyć zawartość patelni, na wierzchu ułożyć plasterki ziemniaków, tak aby zachodziły na siebie. Ziemniaki posmarować roztopionym masłem lub oliwą i wstawić do nagrzanego piekarnika. Piec bez przykrycia przez 25 minut, następnie ustawić funkcję grilla i zapiekać jeszcze przez około 10 minut, aż ziemniaki będą ładnie zrumienione (jeśli piekarnik nie ma grilla, zwiększyć temperaturę do maksimum i zapiekać do zrumienienia). Nakładać na podgrzane talerze."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "ZAPIEKANKA MAKARONOWA Z DYNIĄ, KURCZAKIEM I SUSZONYMI GRZYBAMI",
                Image = "~/Images/Recipes/Dishes/22.jpg",
                SpicyValue = dishParameters[21][0],
                SaltyValue = dishParameters[21][1],
                BitterValue = dishParameters[21][2],
                SweetValue = dishParameters[21][3],
                MeatValue = dishParameters[21][4],
                SourValue = dishParameters[21][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "borowiki,makaron,kurczak,słodka papryka,oliwa,dynia,cebula,śmietanka,tymianek",
                Ingredients = "garść suszonych borowików, 200 g makaronu w kształcie rurek (u mnie - makaron kukurydziany), 1 duża podwójna pierś kurczaka, sól morska i świeżo zmielony pieprz, 2 łyżeczki słodkiej papryki w proszku, 2 łyżki mąki, 2 łyżki oliwy z oliwek, 450 g upieczonej w piekarniku dyni, pokrojonej w kostkę, 1/3 cytryny, 1/2 cebuli, pokrojonej w kosteczkę, 1 łyżka masła, 1/2 szklanki bulionu z kurczaka, 4 - 5 łyżek śmietanki do sosów 18%, 4 łyżki oliwy z oliwek extra virgin, 10 gałązek świeżego tymianku",
                Description = "Grzyby opłukać, włożyć do rondelka i zalać 1 szklanką chłodnej wody. Moczyć przez 2 - 3 godziny lub minimum 1/2 godziny. Makaron gotować w osolonej wodzie kilka minut krócej niż podany czas na opakowaniu, odcedzić i włożyć do dużej formy żaroodpornej. Piersi kurczaka przekroić na pół, wyciąć włókna i kostki. Opłukać i osuszyć. Oprószyć solą, pieprzem, papryką w proszku, obtoczyć w mące. Na patelni rozgrzać 1 łyżkę oliwy i smażyć piersi po około 5 - 6 minut z każdej strony, aż będą ładnie zrumienione. Dodać upieczoną dynię, doprawić solą i pieprzem, podgrzewać razem przez około 2 - 3 minuty. Wycisnąć sok z 1/3 cytryny i wyłożyć wszystko na makaron. Skórkę z cytryny pokroić na kawałki i poukładać przy brzegach w naczyniu. Na patelni rozgrzać 1 łyżkę oliwy i zeszklić cebulkę. Grzyby wyjąć z wody (wywar zachować) i włożyć na patelnię, dodać 1 łyżkę masła i dusić na małym przez 5 minut, mieszając od czasu do czasu. Wlać wywar z grzybów, bulion z kurczaka, doprawić solą i pieprzem, zagotować. Wlać śmietankę i doprowadzić do wrzenia. Zdjąć z ognia i wymieszać z oliwą z oliwek extra virgin. Wyjąć grzyby z patelni i powciskać je w przestrzenie między kurczakiem i dynią w naczyniu żaroodpornym. Całość polać sosem grzybowym z patelni. Do środka zapiekanki powciskać gałązki tymianku. Posypać świeżo zmielonym pieprzem. Wstawić do piekarnika nagrzanego do 200 stopni i zapiekać przez około 15 - 20 minut, aż kurczak będzie miękki w środku."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "KURCZAK W ORZECHACH",
                Image = "~/Images/Recipes/Dishes/23.jpg",
                SpicyValue = dishParameters[22][0],
                SaltyValue = dishParameters[22][1],
                BitterValue = dishParameters[22][2],
                SweetValue = dishParameters[22][3],
                MeatValue = dishParameters[22][4],
                SourValue = dishParameters[22][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "kurczak,orzechy włoskie,parmezan,natka pietruszki,jajko",
                Ingredients = "300 g piersi kurczaka, 4 łyżki rozdrobnionych orzechów włoskich, 2 łyżki bułki tartej, 2 łyżki tartego Parmezanu, 1 łyżka posiekanej natki pietruszki, sól, pieprz 1 jajko, 1 ogórek, 2 łyżki posiekanej natki pietruszki, 2 dymki (młode cebulki ze szczypiorkiem)",
                Description = "Piersi przekroić na 2 części i rozbić tłuczkiem, szczególnie w najgrubszych miejscach, na ok. 1 cm filety. Do miseczki włożyć orzechy (można je rozdrobnić w mini melakserze lub drobno posiekać na desce), dodać bułkę tartą, ser i natkę pietruszki. Doprawić solą, pieprzem i wymieszać. Piersi obtoczyć w roztrzepanym, doprawionym solą i pieprzem jajku a później dokładnie w panierce. Rozgrzać patelnię z olejem roślinnym na głębokość ok. 1 cm. Smażyć filety z dwóch stron na złoty kolor na średnim ogniu przez około 3-4 minuty. Posypać natką pietruszki i podawać z kawałkami cytryny. Surówka z ogórka z sosem francuskim: ogórka obrać i pokroić na cienkie plasterki, dodać posiekaną natkę, cienko pokrojone dymki (białą cebulkę i jasnozielone części szczypiorów). Składniki sosu wymieszać w miseczce i dodać so surówki, wymieszać."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "DORSZ W POMIDORACH Z TYMIANKIEM",
                Image = "~/Images/Recipes/Dishes/24.jpg",
                SpicyValue = dishParameters[23][0],
                SaltyValue = dishParameters[23][1],
                BitterValue = dishParameters[23][2],
                SweetValue = dishParameters[23][3],
                MeatValue = dishParameters[23][4],
                SourValue = dishParameters[23][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,szczypiorek,cebula,pomidor,brązowy cukier,sos sojowy,tymianek,dorsz,pomidorki koktajlowe",
                Ingredients = "oliwa extra vergine, 2 dymki (młode szczypiorki z cebulką), 1/2 puszki pomidorów, 1 łyżeczka brązowego cukru, 1 łyżka sosu sojowego, 3 gałązki świeżego tymianku, 2 filety z dorsza, po ok. 150 g, 2 gałązki pomidorków koktajlowych",
                Description = "Na patelni na 1 łyżce oliwy zeszklić pokrojoną na plasterki dymkę. Dodać pokrojone lub zmiksowane obrane pomidory, brązowy cukier, sos sojowy i oberwane listki tymianku, zagotować. Gotować na małym ogniu przez ok. 5 minut, następnie włożyć filety dorsza doprawione solą i pieprzem. Przykryć i gotować przez ok. 8 minut. W międzyczasie gałązki pomidorków posmarować oliwą, ułożyć na blaszce i piec przez kilka minut pod średnio rozgrzanym grillem w piekarniku."
            });

            context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            {
                Name = "CHILI CON CARNE",
                Image = "~/Images/Recipes/Dishes/25.jpg",
                SpicyValue = dishParameters[24][0],
                SaltyValue = dishParameters[24][1],
                BitterValue = dishParameters[24][2],
                SweetValue = dishParameters[24][3],
                MeatValue = dishParameters[24][4],
                SourValue = dishParameters[24][5],
                CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dishes") == 0).Select(category => category.Id).FirstOrDefault(),
                IngredientsVector = "oliwa,cebula,czosnek,chili,kmin rzymski,oregano,wołowina,pomidor,czerwona papryka,czerwona fasola,suszone pomidory,boczek",
                Ingredients = "1 łyżka oliwy, 1 cebula, 2 ząbki czosnku, 1 łyżeczka chilli w proszku, 1 łyżeczka zmielonego kminu rzymskiego (kuminu), 1 łyżeczka suszonego oregano, 500 g mielonej wołowiny (np. gulaszowej, antrykotu), 2 świeże pomidory lub 2/3 puszki obranych pomidorów, 1 łyżeczka cukru, 1 czerwona papryka, 200 g czerwonej fasoli (ugotowanej), około 100 ml bulionu np. WOŁOWEGO lub wody, opcjonalnie: 100 g boczku, 5 kawałków suszonych pomidorów",
                Description = "Na dużej patelni, na oliwie zeszklić pokrojoną w kosteczkę cebulę, dodać starty czosnek, chilli, kmin rzymski i oregano i mieszając smażyć przez 1 minutę. Stopniowo dodawać zmieloną wołowinę i zmielony lub drobno posiekany boczek, mieszając zrumieniać z każdej strony. Dodać pomidory (świeże należy sparzyć, obrać, pokroić na ćwiartki, usunąć pestki, miąższ pokroić w kosteczkę, pomidory z puszki należy rozdrobnić jeśli są w całości). Wymieszać i doprawić cukrem, pieprzem oraz szczyptą soli. Przykryć i dusić przez około 20 na umiarkowanym ogniu, co jakiś czas zamieszać. Dodać pokrojoną w kosteczkę paprykę i posiekane suszone pomidory jeśli ich używamy. Gotować pod przykryciem przez około 10 minut, od czasu do czasu zamieszać. Na koniec dodać fasolę i gotować pod przykryciem przez ok. 3 minuty. Na koniec gotować potrawę podlewając stopniowo wrzącym bulionem lub wodą, tak aby powstało trochę gęstego sosu. Można przygotować wcześniej i odgrzewać."
            });
            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CARROT CAKE #1",
            //    Description = "In one bowl sift all-purpose flour with sugar, baking powder, soda powder and spices. In another one mix eggs with oil. Combine ingredients from two bowls. Add carrots, pineapple and nuts. Put pie in 20cm-diameter form and bake for about 45 minutes. Leave it to cool down. Cut it along. Mix well all ingredients for cream. Spread over the inside and the topping. Decorate top with nuts.",
            //    Ingredients = "0.5 glass: all-purpose flour, sugar, 1 spoon: soda powder, baking powder, cinnamon, gingerbread spices, 0.3 cup vegetable oil, 2 fluffy eggs, 1 cup: nuts, grated carrot, few slices of pineapple, cream: 300g mascarpone, 6 tablespoons butter, 1.5 cup powdered sugar, 1 spoon vanilla extract",
            //    Temperature = "175",
            //    Time = "45 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/1.png"               
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CINNAMON ROLLS",
            //    Description = "Sift flour. Heat up milk with sugar. Pour half of it to glass with yeast. Another half mix with butter and heat. Fluff eggs and add them to flour. Pour yeast and slowly add milk with butter. Mix precisely and knead it. Leave in warm place to grow. Roll it and smear with butter. Sprinkle with sugar and cinnamon. Collapse it and cut into pieces. Spread with fluffy eggs. Bake.",
            //    Ingredients = "550g all-purpose flour, yeast, 3 tablespoons sugar, 300ml milk, 80g butter, 3 small eggs, cinnamon",
            //    Temperature = "175",
            //    Time = "30 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cookies") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cookies/2.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CHOCOLATE AND BANANA",
            //    Description = "In one bowl mash two bananas. Next add egg and vegetable oil. Mix them up. In another bowl mix flour, sugar, cacao, baking powder with baking soda. Combine ingredients from two bowls. At the end add chopped white chocolate. Leave a little bit for top decoration. Bake for about 20 minutes.",
            //    Ingredients = "1.5 cup all-purpose flour, 0.5 cup sugar, 0.25 cup cocoa, 1 spoon baking soda, 1 spoon baking powder, 3 bananas, 0.3 cup vegetable oil, 1 egg, 1 white chocolate",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/3.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "OREO",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. Add smashed oreo cookies at the end. Bake for about 20 minutes. Start decoration when muffins are cooled down. Decorate each one with whipped cream and one Oreo cookie.",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 24 oreo cookies, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/4.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "GINGERBREAD",
            //    Description = "In one bowl mix honey with eggs, buttermilk and vegetable oil. In another one mix flour with sugar, cacao, baking powder, baking soda and all spices. Combine ingredients from two bowls. Add grated apple and nuts at the end. Decorate top of each muffins with nuts. Bake for about 20 minutes.",
            //    Ingredients = "1.5 cup all-purpose flour, 0.5 cup: rye flour, sugar, honey, 1 spoon: baking powder, soda powder, gingerbread spices, 1 cup buttermilk, 1 egg, 50g oil, 2 tablespoons cocoa, 1 apple, 50 g of nuts",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/5.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "SNICKERS",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. Chop snickers bars into dice and add them at the end. Leave a little bit for top decoration. Bake for about 20 minutes.",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 3 snickers bars, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/6.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "BLUEBERRY",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. At the end add chopped white chocolate and blueberries, but leaving a little bit for top decoration. Bake for about 20 minutes.",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 1 white chocolate, 300g blueberries, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/7.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "STRAWBERRY",
            //    Description = "In one bowl mix vegetable oil with yogurt and eggs. In another one mix flour with sugar and baking powder. Combine ingredients from two bowls. At the end add chopped strawberries. Bake for about 20 minutes. ",
            //    Ingredients = "2.5 cup all-purpose flour, 0.5 cup sugar, 1 spoon baking powder, 300g strawberries, 2 eggs, 1 cup yogurt, 100ml vegetable oil",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/8.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "SPINACH SPAGHETTI",
            //    Description = "Cook pasta. Heat olive oil on pan. Add spinach, onion, garlic and spices. Add chopped salmon. At the and add yogurt. Mix with pasta.",
            //    Ingredients = "200g pasta, 500g spinach, 100g smoked salmon, onion, garlic, spices, 100g yogurt",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dinners") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Dinners/9.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "GREEN SMOOTHIE",
            //    Description = "Using blender mix spinach with banana and apple juice.",
            //    Ingredients = "1 banana, 250ml apple juice, 250g spinach",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Shakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Shakes/10.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "RHUBARB CAKE",
            //    Description = "Chop rhubarb and sprinkle it with sugar. Leave it for about one hour to get rid of water. Mix butter with sugar, cream, yolk and vanilla extract. At the end add two types of flour. Knead shortly and put in the fridge for about 30 minutes. Spread form with butter. Roll cake into the form. Bake for 10 minutes in 200 degrees. Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. Put pudding on baked pie and rhubarb. Bake for about 25 minutes.",
            //    Ingredients = "150g all-purpose flour, 150g rough flour, 200g butter, 100g sugar, 1 yolk, 2 tablespoons cream, 1 spoon vanilla extract, 3 rhubarb stalks, Pudding: 30g of all purpose flour, 3 yolks, 90g of sugar, 250ml of milk, 1 spoon of vanilla extract",
            //    Temperature = "175",
            //    Time = "25 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/11.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "OREO CHEESECAKE",
            //    Description = "Oreo cookies (without cream!) mix with melted butter. Put it at the bottom of form. Mix cheese with mascarpone, condensed milk and sugar. Mix shortly. While mixing add albumen and potato flour. Add few crumbled oreo cookies. Put the mixture in the form. Bake it for about one hour. When it will be cool down put it in the fridge overnight. Decorate top with whipped cream and oreo cookies. ",
            //    Ingredients = "500g cottage cheese, 250g mascarpone, 150g condensed milk, 2 tablespoons powdered sugar, 2 spoons potato flour, 3 albumen, 3 tablespoons butter, 150g oreo cookies",
            //    Temperature = "150",
            //    Time = "60 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/12.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "NUTELLA CHEESECAKE",
            //    Description = "Mix crushed Oreo with butter and press it in the bottom of form. Melt gelatin in the water. Beat cream cheese and powdered sugar. Add nutella and mascarpone and mix well. Spread the cheesecake filling over the crust and leave it overnight in the fridge. You can decorate it with melted chocolate.",
            //    Ingredients = "500g cottage cheese, 250g mascarpone, 150g condensed milk, 2 tablespoons powdered sugar, 2 spoons potato flour, 3 al3 tablespoons butter, 12 oreo cookies, 500g cream cheese, 1.5 cups powdered sugar, 0.5 cup Nutella, 1 cup mascarpone, 3 spoon gelatin melted in 2 tablespoon waterbumen, 3 tablespoons butter, 150g oreo cookies",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/13.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "BLUEBERRY SHAKE",
            //    Description = "Add protein powder to buttermilk, shake well. Using blender mix it with blueberries.",
            //    Ingredients = "250ml buttermilk, 30g protein powder, 200g blueberries",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Shakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Shakes/14.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "RASPBERRY CAKE",
            //    Description = "Mix butter with sugar, cream, yolk and vanilla extract. At the end add two types of flour. Knead shortly and put in the fridge for about 30 minutes. Spread form with butter. Roll cake into the form. Bake for 10 minutes in 200 degrees. Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. Put on baked pie pudding and raspberries. Cover it with almonds. Bake for about 25 minutes.",
            //    Ingredients = "150g all-purpose flour, 150g rough flour, 200g butter, 100g sugar, 1 yolk, 2 tablespoons cream, 1 spoon vanilla extract, 500g raspberries, Pudding: 30g of all purpose flour, 3 yolks, 90g of sugar, 250ml of milk, 1 spoon of vanilla extract",
            //    Temperature = "175",
            //    Time = "25 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/15.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "PEANUT CHEESE CAKE",
            //    Description = "Mix peanut butter with cookies. Put it at the bottom of 30cm-diameter form. Mix well cheese with mascarpone, heavy cream and vanilla extract. Add eggs and mix again. At the end add two types of flour, sugar powder and melted white chocolate. Put mixture in the form. Bake in 220 degrees for 15 minutes, and for the next two hours lower the temperature to 100 degrees and bake for next 2 hours. When the cake will cool down decorate with dulce de leche and nuts.",
            //    Ingredients = "1000g cheese, 200g mascarpone, 150g sugar powder, 4 tablespoons peanut butter, 2 tablespoons potato flour, 2 tablespoons all-purpose flour, 5 eggs, 100g white chocolate, 200g heavy cream, 1 spoon vanilla extract, 100g peanut in honey, 200g cookies, 200g dulce de leche",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/16.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "RHUBARB WITH PUDDING",
            //    Description = "Chop rhubarb and sprinkle it with sugar. Leave it for about one hour to get rid of water.  Prepare pudding: mix 0.5 cup of milk with flour, yolks, sugar and vanilla extract. Mix until it will be smooth. Boil 0.5 cup of milk and add prepared earlier mixture when milk will boil. Mix it often and be careful not to burn it. In one bowl mix melted butter with egg. Add vanilla extract, egg and yogurt. Mix it well. Add sieved flour with baking powder. Mix everything up. When putting in form do it in layers. Firstly put pie, then pudding and rhubarb. Cover it with pie. Decorate each muffin with rhubarb. Bake for about 20 minutes.",
            //    Ingredients = "2 cups all-purpose flour, 1 spoon baking powder, 0.5 cup sugar, 100g melted butter, 1 egg, 1 cup yogurt, 3 rhubarb stalks, pudding: 1 cup milk, 30g all-purpose flour, 3 yolks, 90g sugar, 1 spoon vanilla extract",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/17.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "MOLE MOUND",
            //    Description = "In one bowl add sieved flour, baking powder, soda powder, cocoa and sugar. In another one mix egg with milk and buttermilk. Combine ingredients from two bowls. Bake for about 20 minutes. When muffins will be cool down make in each one hole with spoon – don’t throw the pie away! Chop banana in small pieces and sprinkle with lemon juice. Melt gelatin in 3 table spoons of hot water and leave to cool down. Whip cream and in the end add sugar powder and gelatin. Mix well. In each muffin hole put firstly chopped banana then add cream and cover with pie. Put in fridge for about one hour. ",
            //    Ingredients = "2 cups all-purpose flour, 0.5 cup sugar, 1 cup milk, 0.5 cup buttermilk, 2 tablespoon cocoa, 1 egg, 1 spoon baking powder, 1 spoon soda powder, 1 banana, cream: 200g 30% sour cream, 1 spoon gelatin, 4 table spoons sugar powder",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/18.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "CARROT CAKE #2",
            //    Description = "Mix well eggs with sugar. While mixing add vegetable oil. Add partially flour with baking powder and soda powder. Add cinnamon and gingerbread spice. At the end add carrots with nuts. Fill 30cm-diameter form with pie and bake it for about 45 minutes. Leave it to cool down. Mix well all ingredients for topping and decorate the cake with it. Add orange for extra decoration. ",
            //    Ingredients = "2 cups grated carrot, 1.5 cup all-purpose flour, 4 eggs, 0.5 cup vegetable oil, 0.5 cup sugar, 1 spoon baking powder, 1 spoon soda powder, 1 spoon cinnamon, 1 spoon gingerbread spice, 1 cap nuts, Topping: 100g cream cheese, 4 spoon honey, 2 tablespoon butter",
            //    Temperature = "175",
            //    Time = "45 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Cakes") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Cakes/19.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "STRAWBERRY MILLET",
            //    Description = "Boil millet in salted water (250ml) for about 10 minutes. Leave it covered to sink the water. Add honey, cinnamon and desiccated coconut. Smashed well strawberries. Put it in jar in layers: millet, strawberries and yogurt. Add favorite nuts.",
            //    Ingredients = "50g millet, cinnamon, 100g yogurt, 1 spoon honey, 2 spoon desiccated coconut, 250g strawberries, nuts",
            //    Temperature = "",
            //    Time = "",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Dinners") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Dinners/20.png"
            //});

            //context.Recipes.AddOrUpdate(recipe => recipe.Name, new Recipe()
            //{
            //    Name = "BANANA & NUTS",
            //    Description = "Mash bananas in one bowl. Add to them buttermilk, honey, eggs and vanilla extract. Mix them well. In another bowl mix flour with sugar, baking powder, soda powder and cinnamon. Combine ingredients from two bowls. Decorate each muffin with mashed nuts. Bake for about 30 minutes..",
            //    Ingredients = "2 cups all-purpose flour, 0.5 cup sugar, 2 table spoons honey, 2 bananas, 200g nuts, 2 eggs, 250 ml buttermilk, 1 spoon soda powder, 1 spoon baking powder, 1 spoon cinnamon, 1 spoon vanilla extract",
            //    Temperature = "175",
            //    Time = "20 min",
            //    CategoryId = context.Categories.Where(category => category.Name.CompareTo("Muffins") == 0).Select(category => category.Id).FirstOrDefault(),
            //    Image = "~/Images/Recipes/Muffins/21.png"
            //});
        }
        #endregion

        #region Ingredients

        private void AddOrUpdateIngredients(BlondsCookingContext context)
        {
            IngredientsHelper helper = new IngredientsHelper();
            var ingredients = helper.GetUniqueIngredients(context);
            foreach (var ingredient in ingredients)
            {
                context.Ingredients.AddOrUpdate(ing => ing.Name, new Ingredient()
                {
                    Name = ingredient
                });
            }
        }

        #endregion
    }
}
