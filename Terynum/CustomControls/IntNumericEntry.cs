namespace Terynum.CustomControls;

/// <summary>
/// A very simple Entry that allows only integers. .Net Maui doesn's have one out of the box. 
/// </summary>
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

    /// <summary>
    /// Selects all text on focus.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void IntNumericEntry_Focused(object sender, FocusEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(10);
            this.CursorPosition = 0;
            this.SelectionLength = this.Text != null ? this.Text.Length : 0;
        });
    }

    /// <summary>
    /// Manages user input to allow only integers and control max and min value.
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
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
