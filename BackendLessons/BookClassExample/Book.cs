
/* "Other objects shouldn't be able to inherit nothing from this class"
 So that's why is sealed*/
sealed class Book
{
    private int _id; // sensible information
    public string Title { get; set; }
    private bool _isAvailable { get; set; } = true; // sensible information

    public Book (string title, int id)
    {
        _id = id;
        Title = title;
    }

    public void Checkout()
    {
        _isAvailable = false;
    }

    public void ShowDetails()
    {
        Console.WriteLine(
            $"Book: {Title},\n" +
            $"Availability: {_isAvailable}"
            );
    }
}