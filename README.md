1-turn on developer mode

2-open vs 2022 run the project to see everything is going well

3- clear the front and backend

4-rerun ur project to see everything is going well

5-create the folders 1- Models 2- DataTransactions

6- create the classes inside the *Models* 
* the class should be public
* [PrimaryKey, AutoIncrement] 
* Install sqlite-net-pcl Package 
* Don't Forget to Add int ID 
* int for int string for strings

example:

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string name { get; set; }
        

7- Create DBTrans Class inside the *DataTransactions* folder


* using YourProjectName.Models;

* the class should be public


// create a constructor inside the class 

public string dbPath;
private SQLiteConnection conn;
public DBTrans(string _dbPath)
{
    this.dbPath = _dbPath;
    Init();
}

 //Create the methods 
 

public void Init()
{
    conn = new SQLiteConnection(this.dbPath);
    conn.CreateTable<YourModelName>();
    conn.CreateTable<YourModelName>();
    conn.CreateTable<YourModelName>();

}

public List<YourModelName> GetAll()
{

    return conn.Table<YourModelsName>().ToList();
}

public void Add(YourModelName instance_name  )
{
    conn = new SQLiteConnection(this.dbPath);
    conn.Insert(instance_name);
}

public void Delete(int instance_name2)
{
    conn = new SQLiteConnection(this.dbPath);
    conn.Delete(new YourModelName { ID  From the Model = instance_name2});
}


//REPEAT THOSE METHODS FOR ALL YOUR MODELS


8- GO TO MauiProgram.cs

string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "YOUR_DATABASE_NAME.db");

builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DBTrans>(s, _dbPath));

9-  GO TO App.Xaml.cs:


    public partial class App : Application
    {
        public static DBTrans DBTrans { get; private set; }
        public App(DBTrans dbtrans)
        {
            InitializeComponent();

            MainPage = new AppShell();
            DBTrans = dbtrans;
        }
    }


=========================================================================

1- Create the pages in the root folder .NET MAUI ContentPage(XAML)

2- Add your Icons in the Resources Folder 
-The images should always be small letter
-Make icons JPG images with size 50x50 using Paint program.

3- Go TO THE AppShell.xaml

* Delete The ShellContent
* Add

<TabBar >

    <Tab Title="" Icon=".jpg">
        <ShellContent ContentTemplate="{DataTemplate local:YourPageName}" Route="YourPageName"  />
    </Tab>

    <Tab Title="" Icon=".jpg">
        <ShellContent ContentTemplate="{DataTemplate local:YourPageName}" Route="YourPageName"  />
    </Tab>

    <Tab Title="" Icon=".jpg">
        <ShellContent ContentTemplate="{DataTemplate local:YourPageName}" Route="YourPageName"  />
    </Tab>

    <Tab Title="" Icon=".jpg">
        <ShellContent ContentTemplate="{DataTemplate local:YourPageName}" Route="YourPageName"  />
    </Tab>

    <Tab Title="" Icon=".jpg">
        <ShellContent ContentTemplate="{DataTemplate local:YourPageName}" Route="YourPageName"  />
    </Tab>

</TabBar>

=========================================================================

1- Design The Frontend 

2-

    <ScrollView>
        <StackLayout>
        </StackLayout>
    </ScrollView>

3-Don't Forget The x:name for Bottuns, Entries, RadioButtons and CheckBoxes


4- Clicked For The Buttons, 


Ready Elements 


<StackLayout Orientation="Horizontal" HorizontalOptions="Center" Padding="10">
    <Entry x:Name="Stu_Name" Placeholder="First Name" WidthRequest="130" BackgroundColor="#FFFFFF" PlaceholderColor="#999999" Margin="0,0,10,0" Keyboard="Text"/>
    <Entry x:Name="Stu_LastName" Placeholder="Last Name" WidthRequest="130" BackgroundColor="#FFFFFF" PlaceholderColor="#999999"  Margin="0,0,10,0" Keyboard="Text"/>
</StackLayout>


----

        <StackLayout Orientation="Horizontal" HorizontalOptions="Start" >
            <StackLayout Orientation="Vertical" VerticalOptions="Center">
                <Label Text="Name"/>
            </StackLayout>
            <Entry WidthRequest="230"/>
        </StackLayout>

------
            <StackLayout Orientation="Vertical" HorizontalOptions="Start">
                <Label Text="Name" WidthRequest="250"/>
                <Entry WidthRequest="250"/>
            </StackLayout>

-------

<Label Text="Fill In Your Informations" FontAttributes="Bold" TextColor="#333333" HorizontalOptions="Center" Margin="0,20,0,10"/>

-----------

**********Picker************

Front:

<Picker x:Name="AgePicker" Title="Select Age" BackgroundColor="#FFFFFF" TextColor="#333333"  TitleColor="#999999">
     <Picker.Items>
         <x:String>18</x:String>
         <x:String>19</x:String>
         <x:String>20</x:String>
         <x:String>21</x:String>
         <x:String>22</x:String>
         <x:String>23</x:String>
         <x:String>24</x:String>
         <x:String>25</x:String>
         <x:String>26</x:String>
         <x:String>27</x:String>
     </Picker.Items>
 </Picker>

Back:


string age;
var selectedage = AgePicker.SelectedItem as string;

if (selectedage== null)
{

    DisplayAlert("Error", "Please fill in your age", "OK");
    return;
}

App.DBTrans.Add(new Models.StudentClass
{
    Name = Stu_Name.Text,
    LastName = Stu_LastName.Text,
    Department = Stu_Dept.Text,
    Gender = gender,
    Age = age, // Add age here
    Email = Stu_Email.Text,
    PhoneNumber = Stu_Phone.Text
});
age = AgePicker.SelectedItem as string;

-----------

<Button Text="Continue" WidthRequest="100" BackgroundColor="#007BFF" TextColor="#FFFFFF" CornerRadius="20" HorizontalOptions="Center" Margin="0,20,0,10"/>

-----------------


<ScrollView BackgroundColor="White" >
                <ListView x:Name="" ItemTapped="" HorizontalOptions="Center" >
                    <ListView.ItemTemplate>
                        <DataTemplate>
                            <ViewCell>
                                <StackLayout>
                                    <Label Text="{Binding }"/>

                                    <Label Text="{Binding }"/>

                                    <Label Text="{Binding }"/>

                                    <Button Text="Delete"
                                            x:Name="Delete_Field"
                                            BindingContext="{Binding }"
                                            Clicked=""
                                            BackgroundColor="#9F3E3E"
                                            />
                                </StackLayout>
                            </ViewCell>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                </ListView>
            </ScrollView> 
----------------------

            <StackLayout WidthRequest="190" 
                     HorizontalOptions="Center">
                <Label 
                Text="Text" 
                   FontAttributes="Bold" 
                FontSize="20"/>

                <StackLayout  
                HorizontalOptions="Center" 
                Orientation="Horizontal">


                    <Button Text="-" 
                        FontSize="20" 
                        x:Name="minus"
                        WidthRequest="40"
                        HeightRequest="40"
                            />


                    <Entry IsEnabled="False" 
                           Text="0"
                           x:Name="value"
                           />

                 <Button Text="+" 
                        FontSize="20" 
                        x:Name="plus"
                        WidthRequest="40"
                        HeightRequest="40"
                            />

                </StackLayout>
            </StackLayout>

===================================================================










