namespace Terynum.CustomControls;

public class IntNumericEntry : Entry
{
    public static readonly BindableProperty MaxProperty = BindableProperty.Create(nameof(Max), typeof(int), typeof(IntNumericEntry), int.MaxValue);
    public int Max
    {
        get => (int)GetValue(MaxProperty);
        set => SetValue(MaxProperty, value);
    }

    public static readonly BindableProperty MinProperty = BindableProperty.Create(nameof(Min), typeof(int), typeof(IntNumericEntry), int.MinValue);
    public int Min
    {
        get => (int)GetValue(MinProperty);
        set => SetValue(MinProperty, value);
    }

    public IntNumericEntry()
    {
        Focused += IntNumericEntry_Focused;
    }

    private void IntNumericEntry_Focused(object sender, FocusEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(10);
            this.CursorPosition = 0;
            this.SelectionLength = this.Text != null ? this.Text.Length : 0;
        });
    }

    protected override void OnTextChanged(string oldValue, string newValue)
    {
        base.OnTextChanged(oldValue, newValue);

        if (newValue == null || string.IsNullOrWhiteSpace(newValue))
            return;

        if (int.TryParse(newValue, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int result))
        {
            if (result > Max)
                this.Text = Max.ToString();
            else if (result < Min)
                this.Text = Min.ToString();
        }
        else
            this.Text = oldValue;
    }
}
