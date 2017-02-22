using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HamburgerMenuItemDemo
{
    [TemplatePart(Name = IconGridTemplateName, Type = typeof(Grid))]
    public class HamburgerMenuItem : Button
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(HamburgerMenuItem), new PropertyMetadata(default(IconElement)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(HamburgerMenuItem), new PropertyMetadata(default(string)));

        private const string IconGridTemplateName = "PART_IconGrid";

        private Grid _iconGrid;

        public HamburgerMenuItem()
        {
            DefaultStyleKey = typeof(HamburgerMenuItem);
        }

        public IconElement Icon
        {
            get
            {
                return (IconElement)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _iconGrid = (Grid)GetTemplateChild(IconGridTemplateName);
            _iconGrid.SizeChanged += IconGrid_SizeChanged;
        }

        private void IconGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _iconGrid.Width = e.NewSize.Height;
        }
    }
}