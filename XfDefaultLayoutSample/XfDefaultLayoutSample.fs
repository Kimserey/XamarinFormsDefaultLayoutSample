namespace XfDefaultLayoutSample

open Xamarin.Forms

type TablePageExample() as self =
    inherit ContentPage(Title = "Table example")

    let table =
        let root = new TableRoot("Root title")
        let firstSection = new TableSection("Section 1 title")
        firstSection.Add(new EntryCell(Label = "Firstname", Placeholder = "Enter firstname here"))
        firstSection.Add(new EntryCell(Label = "Lastname", Placeholder = "Enter lastname here"))
        let secondSection = new TableSection("Section 2 title")
        secondSection.Add(new SwitchCell(Text = "Activate", On = true))
        root.Add(firstSection)
        root.Add(secondSection)
        new TableView(
                Root = root,
                Intent = TableIntent.Data
            )
    
    let layout = new StackLayout()

    do
        layout.Children.Add(table)
        self.Content <- layout

type ListPageExample() as self =
    inherit ContentPage(Title = "List example")

    let priceLayout (thumb: string) color (storeBindingPath: string) (priceBindingPath: string) =
        let layout = new Grid()
        layout.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(1., GridUnitType.Star)))
        layout.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(1., GridUnitType.Star)))
        layout.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(1., GridUnitType.Star)))

        let image = new Image(Source = FileImageSource.op_Implicit thumb, Margin = new Thickness(5.))
        let store = new Label(TextColor = color, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center)
        let price = new Label(TextColor = color, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center)
        store.SetBinding(Label.TextProperty, storeBindingPath)
        price.SetBinding(Label.TextProperty, priceBindingPath, stringFormat = "{0:C2}")
        layout.Children.Add(image, 0, 0)
        layout.Children.Add(store, 1, 0)
        layout.Children.Add(price, 2, 0)

        layout


    let list   = 
        new ListView(
            ItemTemplate = new DataTemplate(fun _ ->
            
                let name        = new Label(HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start)
                let average     = new Label(HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Start)
        
                let layout = 
                    let layout = new Grid(Padding = new Thickness(15.))
                    layout.RowDefinitions.Add(new RowDefinition())
                    layout.RowDefinitions.Add(new RowDefinition())
                    layout.RowDefinitions.Add(new RowDefinition())
                    layout.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(0.4, GridUnitType.Star)))
                    layout.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(0.6, GridUnitType.Star)))
                    layout.Children.Add(name,        0, 0)
                    layout.Children.Add(average,     1, 0)
                    layout.Children.Add(priceLayout "ic_thumb_up_black_24dp.png" Color.Olive "LowerStore" "Low", 1, 1)
                    layout.Children.Add(priceLayout "ic_thumb_down_black_24dp.png" Color.Red "HigherStore" "High", 1, 2)
                    layout

                name.SetBinding(Label.TextProperty, "Title")
                average.SetBinding(Label.TextProperty, "Average", stringFormat = "Avg. {0:C2}")

                box (new ViewCell(View = layout))),
            ItemsSource = [ 
                { Title = "1"; HigherStore = "Tesco"; High = 10.0m; LowerStore = "Tesco"; Low = 10.0m; Average = 10.0m }
                { Title = "2"; HigherStore = "Tesco"; High = 10.0m; LowerStore = "Tesco"; Low = 10.0m; Average = 10.0m }
                { Title = "3"; HigherStore = "Tesco"; High = 10.0m; LowerStore = "Tesco"; Low = 10.0m; Average = 10.0m }
                { Title = "4"; HigherStore = "Tesco"; High = 10.0m; LowerStore = "Tesco"; Low = 10.0m; Average = 10.0m }
            ],
            RowHeight = 150)
    
    let layout = new StackLayout()

    do
        layout.Children.Add(list)
        self.Content <- layout


type GridPageExample() as self =
    inherit ContentPage(Title = "Grid example")

    let layout =
        let grid = new Grid()
        grid.RowDefinitions.Add(new RowDefinition())
        grid.RowDefinitions.Add(new RowDefinition())
        grid.RowDefinitions.Add(new RowDefinition())
        grid.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(1., GridUnitType.Star)))
        grid.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(1., GridUnitType.Star)))
        grid.ColumnDefinitions.Add(new ColumnDefinition(Width = new GridLength(1., GridUnitType.Star)))

        let box1 = new BoxView(BackgroundColor = Color.Blue)
        let box2 = new BoxView(BackgroundColor = Color.Aqua)
        let box3 = new BoxView(BackgroundColor = Color.Yellow)
        let box4 = new BoxView(BackgroundColor = Color.Gray)

        grid.Children.Add(box1, 0, 1, 0, 3)
        grid.Children.Add(box2, 1, 3, 0, 1)
        grid.Children.Add(box3, 1, 3, 1, 2)
        grid.Children.Add(box4, 1, 3, 2, 3)

        grid

    do
        self.Content <- layout

type AbsolutePageExample() as self =
    inherit ContentPage(Title = "Absolute example 0.0")

    let layout = 
        let layout = new AbsoluteLayout()
        let box  = new BoxView(BackgroundColor = Color.Blue)
        layout.Children.Add(box,  new Rectangle(0., 0., 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout

    do
        self.Content <- layout

type AbsolutePageExample'() as self =
    inherit ContentPage(Title = "Absolute example 0.5")

    let layout = 
        let layout = new AbsoluteLayout()
        let box  = new BoxView(BackgroundColor = Color.Blue)
        layout.Children.Add(box,  new Rectangle(0.5, 0.5, 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout

    do
        self.Content <- layout

type AbsolutePageExample''() as self =
    inherit ContentPage(Title = "Absolute example 1.0")

    let layout = 
        let layout = new AbsoluteLayout()
        let box  = new BoxView(BackgroundColor = Color.Blue)
        layout.Children.Add(box,  new Rectangle(1., 1., 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout

    do
        self.Content <- layout

type AbsolutePage() as self =
    inherit ContentPage(Title = "Absolute")

    let layout = 
        let layout = new AbsoluteLayout()

        let box  = new BoxView(BackgroundColor = Color.Blue)
        let box1 = new BoxView(BackgroundColor = Color.Fuchsia)
        let box2 = new BoxView(BackgroundColor = Color.Gray)
        let box3 = new BoxView(BackgroundColor = Color.Yellow)
        let box4 = new BoxView(BackgroundColor = Color.Green)

        layout.Children.Add(box,  new Rectangle(0., 0., 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout.Children.Add(box1, new Rectangle(0.25, 0.25, 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout.Children.Add(box2, new Rectangle(0.5, 0.5, 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout.Children.Add(box3, new Rectangle(0.75, 0.75, 0.25, 0.25), AbsoluteLayoutFlags.All)
        layout.Children.Add(box4, new Rectangle(1., 1., 0.25, 0.25), AbsoluteLayoutFlags.All)

        layout

    do
        self.Content <- layout

type RelativePage() as self =
    inherit ContentPage(Title = "Relative")

    let layout =
        let layout = new RelativeLayout()

        let box = new BoxView(BackgroundColor = Color.Blue)
        layout.Children.Add(
            box,
            Constraint.RelativeToParent(fun parent -> parent.X),
            Constraint.RelativeToParent(fun parent -> parent.Y),
            Constraint.RelativeToParent(fun parent -> (parent.Width * 25.) / 100.),
            Constraint.RelativeToParent(fun parent -> (parent.Height * 25.) / 100.)
        )

        let box2 = new BoxView(BackgroundColor = Color.Fuchsia)
        layout.Children.Add(
            box2,
            Constraint.RelativeToView(box, fun parent view -> view.X + view.Width),
            Constraint.RelativeToView(box, fun parent view -> view.Y + view.Height),
            Constraint.RelativeToParent(fun parent -> (parent.Width * 25.) / 100.),
            Constraint.RelativeToParent(fun parent -> (parent.Height * 25.) / 100.)
        )

        let box3 = new BoxView(BackgroundColor = Color.Gray)
        layout.Children.Add(
            box3,
            Constraint.RelativeToView(box2, fun parent view -> view.X + view.Width),
            Constraint.RelativeToView(box2, fun parent view -> view.Y + view.Height),
            Constraint.RelativeToParent(fun parent -> (parent.Width * 25.) / 100.),
            Constraint.RelativeToParent(fun parent -> (parent.Height * 25.) / 100.)
        )

        let box4 = new BoxView(BackgroundColor = Color.Yellow)
        layout.Children.Add(
            box4,
            Constraint.RelativeToView(box3, fun parent view -> view.X + view.Width),
            Constraint.RelativeToView(box3, fun parent view -> view.Y + view.Height),
            Constraint.RelativeToParent(fun parent -> (parent.Width * 25.) / 100.),
            Constraint.RelativeToParent(fun parent -> (parent.Height * 25.) / 100.)
        )

        layout

    do
        self.Content <- layout

type TabPage() as self =
    inherit TabbedPage()

    do
        self.Children.Add(new TablePageExample())
        self.Children.Add(new ListPageExample())
        self.Children.Add(new GridPageExample())
        self.Children.Add(new RelativePage())
        self.Children.Add(new AbsolutePage())
        self.Children.Add(new AbsolutePageExample())
        self.Children.Add(new AbsolutePageExample'())
        self.Children.Add(new AbsolutePageExample''())

type App() as self =
    inherit Application()

    do
        self.MainPage <- new TabPage()