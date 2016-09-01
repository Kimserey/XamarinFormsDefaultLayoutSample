namespace XfDefaultLayoutSample

open Xamarin.Forms

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
        self.Children.Add(new AbsolutePage())
        self.Children.Add(new RelativePage())

type App() as self =
    inherit Application()

    do
        self.MainPage <- new TabPage()