namespace Lesson5;

public class PhoneBook
{
    private static PhoneBook instance;
    private List<Abonent> _abonents;

    private PhoneBook(string nameFile)
    {
        _abonents = ReadFile(nameFile);
    }

    public static PhoneBook getInstance(string nameFile)
    {
        if (instance == null)
        {
            instance = new PhoneBook(nameFile);
        }

        return instance;
    }

    private static List<Abonent> ReadFile(string nameFile)
    {
        List<Abonent> list = new List<Abonent>();
        try
        {
            StreamReader streamReader = new StreamReader(nameFile);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] lines = line.Split(':');
                string name = lines[0];
                string numberPhone = lines[1];
                list.Add(new Abonent(name, numberPhone));
            }
            streamReader.Close();
        }
        catch (FileNotFoundException e)
        {
            
        }
        
        return list;
    }

    public void SaveList(string nameFile)
    {
        StreamWriter streamWriter = new StreamWriter(nameFile);
        foreach (var abonent in _abonents)
        {
            streamWriter.WriteLine(abonent.GetName() + ":" + abonent.GetNumberPhone());
        }
        streamWriter.Close();
    }

    public void AddAbonent(Abonent addedAbonent)
    {
        Abonent findAbonent = null; //без подобной инициализации вижу ошибку 
        foreach (var abonent in _abonents)
        {
            if (abonent.GetName() == addedAbonent.GetName())
                if (abonent.GetNumberPhone() == addedAbonent.GetNumberPhone())
                    findAbonent = abonent;
        }

        if (findAbonent == null)
        {
            _abonents.Add(addedAbonent);
        }
        else
        {
            throw new ArgumentException("AbonentAlreadyExists", nameof(addedAbonent));
        }
    }

    public void RemoveAbonent(Abonent abonent)
    {
        _abonents.Remove(abonent);
    }

    public void RemoveAbonent(string numberPhone)
    {
        Abonent findAbonent = null;
        foreach (var abonent in _abonents)
        {
            if (abonent.GetNumberPhone() == numberPhone)
                findAbonent = abonent;
        }

        if (findAbonent != null)
        {
            _abonents.Remove(findAbonent);
        }
    }

    public Abonent GetAbonentByNumber(string numberPhone)
    {
        Abonent findAbonent = null;
        foreach (var abonent in _abonents)
        {
            if (abonent.GetNumberPhone() == numberPhone)
                findAbonent = abonent;
        }

        return findAbonent;
    }

    public Abonent GetAbonenetByName(string name)
    {
        Abonent findAbonent = null;
        foreach (var abonent in _abonents)
        {
            if (abonent.GetName() == name)
                findAbonent = abonent;
        }

        return findAbonent;
    }
}