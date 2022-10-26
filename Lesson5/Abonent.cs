namespace Lesson5;

public class Abonent
{
    private string name;
    private string numberPhone;

    public Abonent(string name, string numberPhone)
    {
        this.name = name;
        this.numberPhone = numberPhone;
    }

    public string GetName()
    {
        return this.name;
    }

    public string GetNumberPhone()
    {
        return this.numberPhone;
    }
    
    
    
}



