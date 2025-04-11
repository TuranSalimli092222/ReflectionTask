using System.Reflection;
using Task;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Type type = typeof(User);

        Assembly asm = Assembly.GetExecutingAssembly();
        Type userType = asm.GetTypes().FirstOrDefault(t => t.Name == "User");



        object userInstance = Activator.CreateInstance(userType);

        FieldInfo idField = userType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo nameField = userType.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo surnameField = userType.GetField("surname", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo ageField = userType.GetField("age", BindingFlags.NonPublic | BindingFlags.Static);

        idField.SetValue(userInstance, 1);
        nameField.SetValue(userInstance, "Turan");
        surnameField.SetValue(userInstance, "Developer");
        ageField.SetValue(userInstance, 20);

        Console.WriteLine($"id: {idField.GetValue(userInstance)}");
        Console.WriteLine($"name: {nameField.GetValue(userInstance)}");
        Console.WriteLine($"surname: {surnameField.GetValue(userInstance)}");
        Console.WriteLine($"age: {ageField.GetValue(userInstance)}");

        MethodInfo getFullNameMethod = userType.GetMethod("GetFullName", BindingFlags.Public | BindingFlags.Instance);
        getFullNameMethod.Invoke(userInstance, null);

        MethodInfo changeAgeMethod = userType.GetMethod("ChangeAge", BindingFlags.Public | BindingFlags.Static);
        changeAgeMethod.Invoke(userInstance, [25]);

        Console.WriteLine($"age: {ageField.GetValue(userInstance)}");
    }
}


