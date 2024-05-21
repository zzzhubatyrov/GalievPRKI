using PRKI.AbstractFactory;
using PRKI.Composite;
using PRKI.FactoryMethod;
using PRKI.Interpreter;
using PRKI.Observer;
using PRKI.Prototype;
using PRKI.State;
using PRKI.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRKI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Builder
            // 1.
            var director = new CarDirector();
            var standardCarBuilder = new StandardCarBuilder();
            director.Construct(standardCarBuilder);
            Car standardCar = standardCarBuilder.GetCar();
            Console.WriteLine(standardCar);

            var customCarBuilder = new CustomCarBuilder();
            director.Construct(customCarBuilder);
            Car customCar = customCarBuilder.GetCar();
            Console.WriteLine(customCar);

            // 2.
            var bandDirector = new BandDirector();
            var singingBandBuilder = new SingingBandBuilder();
            bandDirector.Construct(singingBandBuilder);
            MusicBand singingBand = singingBandBuilder.GetBand();
            Console.WriteLine(singingBand);

            var dancingBandBuilder = new DancingBandBuilder();
            bandDirector.Construct(dancingBandBuilder);
            MusicBand dancingBand = dancingBandBuilder.GetBand();
            Console.WriteLine(dancingBand);

            var mixedBandBuilder = new MixedBandBuilder();
            bandDirector.Construct(mixedBandBuilder);
            MusicBand mixedBand = mixedBandBuilder.GetBand();
            Console.WriteLine(mixedBand);

            // 3.
            var mealDirector = new MealDirector();
            var standardMealBuilder = new StandardMealBuilder();
            mealDirector.Construct(standardMealBuilder);
            Meal standardMeal = standardMealBuilder.GetMeal();
            Console.WriteLine(standardMeal);

            var customMealBuilder = new CustomMealBuilder();
            mealDirector.Construct(customMealBuilder);
            Meal customMeal = customMealBuilder.GetMeal();
            Console.WriteLine(customMeal);

            // 4.
            //string filePath = "article.txt";
            //var builder = new ArticleBuilder();
            //var articleDirector = new ArticleDirector();
            //articleDirector.Construct(builder, filePath);

            //Article article = builder.GetArticle();

            //if (ArticleConverter.ValidateHash(article))
            //{
            //    XDocument xml = ArticleConverter.ConvertToXml(article);
            //    xml.Save("article.xml");
            //    Console.WriteLine("Article successfully converted to XML.");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid article hash.");
            //}

            // Abstract Factory
            // 1.
            IAFDAOFactory dbFactory = new DatabaseDAOFactory();
            DAO dbDAO = dbFactory.CreateDAO();

            IAFDAOFactory xmlFactory = new XMLDAOFactory();
            DAO xmlDAO = xmlFactory.CreateDAO();
            PhoneCall call = new PhoneCall
            {
                Caller = "Alice",
                Receiver = "Bob",
                CallTime = DateTime.Now,
                Duration = 120
            };
            dbDAO.SaveCall(call);
            xmlDAO.SaveCall(call);
            var dbCalls = dbDAO.GetAllCalls();
            var xmlCalls = xmlDAO.GetAllCalls();
            Console.WriteLine("Database Calls:");
            foreach (var c in dbCalls)
            {
                Console.WriteLine($"{c.Caller} called {c.Receiver} for {c.Duration} seconds at {c.CallTime}");

            }
            Console.WriteLine("XML Calls:");
            foreach (var c in xmlCalls)
            {
                Console.WriteLine($"{c.Caller} called {c.Receiver} for {c.Duration} seconds at {c.CallTime}");
            }
            // 2.
            User user = new User
            {
                Username = "JohnDoe",
                Email = "john.doe@example.com",
                AdditionalData = new Dictionary<string, string>
            {
                { "Phone", "123-456-7890" },
                { "Address", "123 Main St" }
            }
            };
            dbDAO.SaveUser(user);
            xmlDAO.SaveUser(user);
            var dbUsers = dbDAO.GetAllUsers();
            var xmlUsers = xmlDAO.GetAllUsers();
            Console.WriteLine("Database Users:");
            foreach (var u in dbUsers)
            {
                Console.WriteLine($"Username: {u.Username}, Email: {u.Email}, AdditionalData: {string.Join(", ", u.AdditionalData)}");
            }
            Console.WriteLine("XML Users:");
            foreach (var u in xmlUsers)
            {
                Console.WriteLine($"Username: {u.Username}, Email: {u.Email}, AdditionalData: {string.Join(", ", u.AdditionalData)}");
            }
            // 3.
            Movie movie = new Movie
            {
                Title = "Inception",
                AudioLanguage = "English",
                SubtitleLanguage = "English"
            };
            dbDAO.SaveMovie(movie);
            xmlDAO.SaveMovie(movie);
            var dbMovies = dbDAO.GetAllMovies();
            var xmlMovies = xmlDAO.GetAllMovies();
            Console.WriteLine("Database Movies:");
            foreach (var m in dbMovies)
            {
                Console.WriteLine($"Title: {m.Title}, Audio: {m.AudioLanguage}, Subtitles: {m.SubtitleLanguage}");
            }
            Console.WriteLine("XML Movies:");
            foreach (var m in xmlMovies)
            {
                Console.WriteLine($"Title: {m.Title}, Audio: {m.AudioLanguage}, Subtitles: {m.SubtitleLanguage}");
            }
            // Prototype
            // 1.
            ArticleManager manager = new ArticleManager();

            ArticleWiki article1 = new ArticleWiki("Article 1", "Content of Article 1", "Author A");
            ArticleWiki article2 = new ArticleWiki("Article 2", "Content of Article 2", "Author B");
            manager.AddArticle(article1);
            manager.AddArticle(article2);
            manager.DisplayArticles();
            ArticleWiki editableArticle = manager.GetEditableArticle("Article 1");
            editableArticle.Content = "Updated Content of Article 1";
            editableArticle.LastModified = DateTime.Now;
            Console.WriteLine("\nAfter Editing:");
            manager.DisplayArticles();
            manager.RestoreArticle("Article 1");
            Console.WriteLine("\nAfter Restoration:");
            manager.DisplayArticles();

            // Factory Method
            // 1.
            TetrisFigureFactory factory = new RandomTetrisFigureFactory();

            for (int i = 0; i < 10; i++)
            {
                TetrisFigure figure = factory.CreateFigure();
                Console.WriteLine($"Generated figure: {figure.Name}");
                PrintShape(figure.Shape);
                Console.WriteLine();
            }

            // Interpreter
            Dictionary<string, ComplexNumber> context = new Dictionary<string, ComplexNumber>
            {
                { "a", new ComplexNumber(3, 2) },
                { "b", new ComplexNumber(1, 7) }
            };
            IExpression expr1 = new Add(new Variable("a"), new Variable("b"));
            IExpression expr2 = new And(new Variable("a"), new Variable("b"));
            IExpression expr3 = new Xor(new Variable("a"), new Constant(new ComplexNumber(2, 3)));

            Console.WriteLine($"a + b = {expr1.Interpret(context)}");
            Console.WriteLine($"a & b = {expr2.Interpret(context)}");
            Console.WriteLine($"a ^ (2 + 3i) = {expr3.Interpret(context)}");

            // Strategy
            Character orc = new Orc(new WalkStrategy());
            Character pegasus = new Pegasus(new FlyStrategy());
            Character vampire = new Vampire(new WalkAndFlyStrategy());
            Character elf = new Elf(new MagicFlyStrategy());
            orc.Display();
            orc.Move();
            pegasus.Display();
            pegasus.Move();
            vampire.Display();
            vampire.Move();
            elf.Display();
            elf.Move();
            orc.SetMovementStrategy(new FlyStrategy());
            orc.Move();

            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            ArrayContext arrContext = new ArrayContext();
            arrContext.SetSortStrategy(new BubbleSortStrategy());
            arrContext.Sort(array);
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
            arrContext.SetSearchStrategy(new MaxValueStrategy());
            int maxValue = arrContext.Search(array);
            Console.WriteLine("Максимальное значение: " + maxValue);
            arrContext.SetSortStrategy(new QuickSortStrategy());
            arrContext.Sort(array);
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
            arrContext.SetSearchStrategy(new MinValueStrategy());
            int minValue = arrContext.Search(array);
            Console.WriteLine("Минимальное значение: " + minValue);

            // Observer
            Publisher newspaperPublisher = new Publisher("Газетное Издательство");
            Publisher magazinePublisher = new Publisher("Журнальное Издательство");

            PostOffice postOffice = new PostOffice("Почтовое Отделение");

            Subscriber alice = new Subscriber("Алиса");
            Subscriber bob = new Subscriber("Боб");
            Subscriber charlie = new Subscriber("Чарли");

            postOffice.Subscribe(alice);
            postOffice.Subscribe(bob);
            postOffice.Subscribe(charlie);

            newspaperPublisher.Subscribe(postOffice);
            magazinePublisher.Subscribe(postOffice);

            newspaperPublisher.Notify("Газета №1");
            magazinePublisher.Notify("Журнал №1");

            postOffice.Unsubscribe(bob);

            newspaperPublisher.Notify("Газета №2");
            magazinePublisher.Notify("Журнал №2");

            // State
            // 1.
            GrantRequest request = new GrantRequest();

            Console.WriteLine($"Текущее состояние: {request.GetStateName()}");
            request.HandleRequest();
            Console.WriteLine($"Текущее состояние: {request.GetStateName()}");
            request.HandleRequest();
            Console.WriteLine($"Текущее состояние: {request.GetStateName()}");
            request.HandleRequest();
            Console.WriteLine($"Текущее состояние: {request.GetStateName()}");
            // 2.
            Assignment assignment = new Assignment();

            Console.WriteLine($"Текущее состояние: {assignment.GetStateName()}");
            assignment.HandleAssignment();
            Console.WriteLine($"Текущее состояние: {assignment.GetStateName()}");
            assignment.HandleAssignment();
            Console.WriteLine($"Текущее состояние: {assignment.GetStateName()}");
            assignment.HandleAssignment();
            Console.WriteLine($"Текущее состояние: {assignment.GetStateName()}");
            assignment.HandleAssignment();
            Console.WriteLine($"Текущее состояние: {assignment.GetStateName()}");
            assignment.HandleAssignment();
            Console.WriteLine($"Текущее состояние: {assignment.GetStateName()}");

            // Composite
            // 1.
            Region country = new Region("Страна");
            Region region1 = new Region("Регион 1");
            region1.Add(new City("Город 1"));
            region1.Add(new City("Город 2"));
            Region region2 = new Region("Регион 2");
            region2.Add(new City("Город 3"));
            region2.Add(new City("Город 4"));
            country.Add(region1);
            country.Add(region2);
            country.Display(1);
            // 2.
            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(new Word("Это "));
            paragraph1.Add(new Word("первый "));
            paragraph1.Add(new Word("параграф."));
            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(new Word("Это "));
            paragraph2.Add(new Word("второй "));
            paragraph2.Add(new Word("параграф."));
            paragraph1.Display();
            paragraph2.Display();
            // 3.
            Army elfArmy = new Army();
            elfArmy.Add(new Warrior("Эльф 1"));
            elfArmy.Add(new Warrior("Эльф 2"));
            Army orcArmy = new Army();
            orcArmy.Add(new Warrior("Орк 1"));
            orcArmy.Add(new Warrior("Орк 2"));
            Army fantasyArmy = new Army();
            fantasyArmy.Add(elfArmy);
            fantasyArmy.Add(orcArmy);
            fantasyArmy.Add(new Warrior("Минотавр"));
            fantasyArmy.Add(new Warrior("Циклоп"));
            fantasyArmy.Display();
            // 4.
            Directory root = new Directory("Root");
            Directory documents = new Directory("Documents");
            Directory images = new Directory("Images");
            File textFile = new File("TextFile.txt");
            File jpegFile = new File("Image.jpg");
            documents.Add(textFile);
            images.Add(jpegFile);
            root.Add(documents);
            root.Add(images);
            root.Display("");

            // Flyweight
            BacteriaFactory factoryFW = new BacteriaFactory();
            BacteriaInternalState internalState = new BacteriaInternalState();
            IBacteriaExternalState type = factoryFW.GetBacteriaType("Escherichia coli");
            Bacteria bacteria1 = new Bacteria(0, 0, type, internalState);
            Bacteria bacteria2 = new Bacteria(10, 10, type, internalState);
            IBacteriaExternalState redColor = factoryFW.GetBacteriaColor("Red");
            Bacteria bacteria3 = new Bacteria(5, 5, redColor, internalState);
            bacteria1.Display();
            bacteria2.Display();
            bacteria3.Display();

            // Decorator
            // 1.
            IRecipe originalRecipe = new Recipe("Dr. Smith", DateTime.Now.AddDays(7));
            originalRecipe.PrintInfo();
            IRecipe extendedRecipe = new RecipeExpirationDateDecorator(originalRecipe, DateTime.Now.AddDays(14));
            extendedRecipe.PrintInfo();
            // 2.
            IFlowerBouquet bouquet = new FlowerBouquet();
            IFlowerBouquet bouquetWithRibbon = new RibbonDecorator(bouquet, "Flower Shop Inc.");
            bouquetWithRibbon.Assemble();

            // Chain of resposobility
            var regularHandler = new RegularPaymentHandler();
            var discountedHandler = new DiscountedPaymentHandler();
            var governmentHandler = new GovernmentPaymentHandler();
            var internalHandler = new InternalPaymentHandler();

            regularHandler.SetNextHandler(discountedHandler);
            discountedHandler.SetNextHandler(governmentHandler);
            governmentHandler.SetNextHandler(internalHandler);

            var payment1 = new Payment { Type = PaymentType.Regular };
            var payment2 = new Payment { Type = PaymentType.Government };
            var payment3 = new Payment { Type = PaymentType.Internal };

            regularHandler.HandlePayment(payment1);
            regularHandler.HandlePayment(payment2);
            regularHandler.HandlePayment(payment3);

            // Memento
            // 1.
            int[,] initialBoard = new int[9, 9]
            {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

            SudokuBoard sudokuBoard = new SudokuBoard(initialBoard);
            GameHistory history = new GameHistory();

            Console.WriteLine("Initial Sudoku Board:");
            sudokuBoard.PrintBoard();

            sudokuBoard.MakeMove(0, 2, 4);
            sudokuBoard.MakeMove(2, 0, 1);

            history.SaveState(sudokuBoard.Save());

            Console.WriteLine("\nSudoku Board after some moves:");
            sudokuBoard.PrintBoard();

            Memento lastState = history.Undo();
            if (lastState != null)
            {
                sudokuBoard.Restore(lastState);
                Console.WriteLine("\nSudoku Board after undo:");
                sudokuBoard.PrintBoard();
            }
            else
            {
                Console.WriteLine("\nNo moves to undo.");
            }
            // 2. empty

            // 3. empty

            // Transport and PassengerCarrier
            double distance = 100;
            PassengerCarrier carrier = new AirplaneCarrier();
            Transport transport = carrier.CreateTransport(distance);
            double time = transport.CalculateTime(distance);
            double cost = transport.CalculateCost(distance);
            Console.WriteLine($"Time: {time} hours");
            Console.WriteLine($"Cost: ${cost}");

        }
        static void PrintShape(int[,] shape)
        {
            int rows = shape.GetLength(0);
            int cols = shape.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(shape[i, j] == 1 ? "X" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
