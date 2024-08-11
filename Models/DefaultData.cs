using EcommerceApp.Data;
using EcommerceApp.Models.Entity.UserAddress;
using EcommerceApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace EcommerceApp.Models;

public class DefaultData
{
    public static async Task AddZila(IServiceProvider service)
    {
        
        var scope = service.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var allZila = db.Zilas.ToList();

        var divisions = Enum.GetValues<Division>();
        foreach (var dp in typeof(Divisions).GetProperties())
        {
            var division = divisions.FirstOrDefault(x => x.ToString().Equals(dp.Name, StringComparison.OrdinalIgnoreCase));
            var type = Activator.CreateInstance(dp.PropertyType);
            foreach (var zp in dp.PropertyType.GetProperties())
            {
                var zila = new Zila
                {
                    Name = zp.Name,
                    Division = division
                };
                await db.AddAsync(zila);
                await db.SaveChangesAsync();
                if (zp.GetValue(type) is List<string> thana)
                {
                    var thanas = new List<Thana>();
                    foreach (var v in thana)
                    {
                        thanas.Add(new Thana
                        {
                            Name = v,
                            ZilaId = zila.Id
                        });
                    }
                    await db.AddRangeAsync(thanas);
                    await db.SaveChangesAsync();
                }
            }
        }
    }

}

public class Divisions
{
    public Chattogram1 Chattogram { get; set; }
    public Dhaka1 Dhaka { get; set; }
    public Khulna1 Khulna { get; set; }
    public Rajshahi1 Rajshahi { get; set; }
    public Barishal1 Barishal { get; set; }
    public Sylhet1 Sylhet { get; set; }
    public Rangpur1 Rangpur { get; set; }
    public Mymensingh1 Mymensingh { get; set; }
}

public class Chattogram1
{
    public List<string> Chattogram { get; set; } = ["Anwara", "Banshkhali", "Boalkhali", "Chandanaish", "Fatikchhari", "Hathazari", "Lohagara", "Mirsharai", "Patiya", "Rangunia", "Raozan", "Sandwip", "Satkania", "Sitakunda"];
    public List<string> Cumilla { get; set; } = new List<string> { "Barura", "Brahmanpara", "Burichang", "Chandina", "Chauddagram", "Daudkandi", "Debidwar", "Homna", "Laksam", "Meghna", "Muradnagar", "Nangalkot", "Titas" };
    public List<string> CoxsBazar { get; set; } = new List<string> { "Chakaria", "Cox's Bazar Sadar", "Kutubdia", "Maheshkhali", "Pekua", "Ramu", "Teknaf", "Ukhia" };
    public List<string> Brahmanbaria { get; set; } = new List<string> { "Akhaura", "Ashuganj", "Bancharampur", "Brahmanbaria Sadar", "Kasba", "Nabinagar", "Nasirnagar", "Sarail" };
    public List<string> Bandarban { get; set; } = new List<string> { "Ali Kadam", "Bandarban Sadar", "Lama", "Naikhongchhari", "Rowangchhari", "Ruma", "Thanchi" };
    public List<string> Chandpur { get; set; } = new List<string> { "Chandpur Sadar", "Faridganj", "Haimchar", "Haziganj", "Kachua", "Matlab Dakshin", "Matlab Uttar", "Shahrasti" };
    public List<string> Feni { get; set; } = new List<string> { "Chhagalnaiya", "Daganbhuiyan", "Feni Sadar", "Fulgazi", "Parshuram", "Sonagazi" };
    public List<string> Khagrachari { get; set; } = new List<string> { "Dighinala", "Khagrachhari", "Lakshmichhari", "Mahalchhari", "Manikchhari", "Matiranga", "Panchhari", "Ramgarh" };
    public List<string> Lakshmipur { get; set; } = new List<string> { "Lakshmipur Sadar", "Raipur", "Ramganj", "Ramgati", "Komol Nagar" };
    public List<string> Noakhali { get; set; } = new List<string> { "Begumganj", "Chatkhil", "Companiganj", "Hatiya", "Kabirhat", "Noakhali Sadar", "Senbagh", "Subarnachar" };
    public List<string> Rangamati { get; set; } = new List<string> { "Baghaichhari", "Barkal", "Kaptai", "Juraichhari", "Kawkhali", "Langadu", "Naniachar", "Rajasthali", "Rangamati Sadar" };
}

public class Dhaka1
{
    public List<string> Dhaka { get; set; } = new List<string> { "Adabor", "Badda", "Bangshal", "Biman Bandar", "Cantonment", "Chawkbazar", "Dakkhin Khan", "Demra", "Dhanmondi", "Gendaria", "Gulshan", "Hazaribagh", "Jatrabari", "Kadamtali", "Kafrul", "Kalabagan", "Kamrangirchar", "Khilkhet", "Khilgaon", "Kotwali", "Lalbagh", "Mirpur", "Mohammadpur", "Motijheel", "New Market", "Pallabi", "Paltan", "Ramna", "Rampura", "Sabujbagh", "Shah Ali", "Shahbagh", "Sher-e-Bangla Nagar", "Shyampur", "Sutrapur", "Tejgaon", "Tejgaon Industrial Area", "Turag", "Uttar Khan", "Uttara" };
    public List<string> Gazipur { get; set; } = new List<string> { "Gazipur Sadar", "Kaliakair", "Kapasia", "Sreepur", "Kaliganj" };
    public List<string> Kishoreganj { get; set; } = new List<string> { "Austagram", "Bajitpur", "Bhairab", "Hossainpur", "Itna", "Karimganj", "Katiadi", "Kishoreganj Sadar", "Kuliarchar", "Mithamain", "Nikli", "Pakundia", "Tarail" };
    public List<string> Madaripur { get; set; } = new List<string> { "Madaripur Sadar", "Kalkini", "Rajoir", "Shibchar" };
    public List<string> Manikganj { get; set; } = new List<string> { "Manikganj Sadar", "Singair", "Shibalaya", "Saturia", "Harirampur", "Ghior", "Daulatpur" };
    public List<string> Munshiganj { get; set; } = new List<string> { "Munshiganj Sadar", "Lohajang", "Sirajdikhan", "Sreenagar", "Gazaria", "Tongibari" };
    public List<string> Narayanganj { get; set; } = new List<string> { "Araihazar", "Bandar", "Narayanganj Sadar", "Rupganj", "Sonargaon" };
    public List<string> Narsingdi { get; set; } = new List<string> { "Narsingdi Sadar", "Belabo", "Monohardi", "Palash", "Raipura", "Shibpur" };
    public List<string> Rajbari { get; set; } = new List<string> { "Baliakandi", "Goalandaghat", "Pangsha", "Kalukhali", "Rajbari Sadar" };
    public List<string> Shariatpur { get; set; } = new List<string> { "Bhedarganj", "Damudya", "Gosairhat", "Naria", "Shariatpur Sadar", "Zajira" };
    public List<string> Tangail { get; set; } = new List<string> { "Tangail Sadar", "Bhuapur", "Delduar", "Dhanbari", "Ghatail", "Gopalpur", "Kalihati", "Madhupur", "Mirzapur", "Nagarpur", "Sakhipur", "Basail" };
}


public class Khulna1
{
    public List<string> Bagerhat { get; set; } = new List<string> { "Bagerhat Sadar", "Chitalmari", "Fakirhat", "Kachua", "Mollahat", "Mongla", "Morrelganj", "Rampal", "Sarankhola" };
    public List<string> Chuadanga { get; set; } = new List<string> { "Alamdanga", "Chuadanga Sadar", "Damurhuda", "Jibannagar" };
    public List<string> Jashore { get; set; } = new List<string> { "Abhaynagar", "Bagherpara", "Chaugachha", "Jashore Sadar", "Jhikargachha", "Keshabpur", "Manirampur", "Sharsha" };
    public List<string> Jhenaidah { get; set; } = new List<string> { "Harinakunda", "Jhenaidah Sadar", "Kaliganj", "Kotchandpur", "Maheshpur", "Shailkupa" };
    public List<string> Khulna { get; set; } = new List<string> { "Batiaghata", "Dacope", "Dumuria", "Dighalia", "Koyra", "Paikgachha", "Phultala", "Rupsa", "Terokhada" };
    public List<string> Kushtia { get; set; } = new List<string> { "Bheramara", "Daulatpur", "Khoksa", "Kumarkhali", "Kushtia Sadar", "Mirpur" };
    public List<string> Magura { get; set; } = new List<string> { "Magura Sadar", "Mohammadpur", "Shalikha", "Sreepur" };
    public List<string> Meherpur { get; set; } = new List<string> { "Gangni", "Meherpur Sadar", "Mujibnagar" };
    public List<string> Narail { get; set; } = new List<string> { "Kalia", "Lohagara", "Narail Sadar" };
    public List<string> Satkhira { get; set; } = new List<string> { "Assasuni", "Debhata", "Kalaroa", "Kaliganj", "Satkhira Sadar", "Shyamnagar", "Tala" };
}


public class Rajshahi1
{
    public List<string> Bogura { get; set; } = new List<string> { "Adamdighi", "Bogra Sadar", "Dhunat", "Dhupchanchia", "Gabtali", "Kahaloo", "Nandigram", "Sariakandi", "Shajahanpur", "Sherpur", "Shibganj", "Sonatala" };
    public List<string> Joypurhat { get; set; } = new List<string> { "Akkelpur", "Joypurhat Sadar", "Kalai", "Khetlal", "Panchbibi" };
    public List<string> Naogaon { get; set; } = new List<string> { "Atrai", "Badalgachhi", "Dhamoirhat", "Manda", "Mohadevpur", "Naogaon Sadar", "Niamatpur", "Patnitala", "Porsha", "Raninagar", "Sapahar" };
    public List<string> Natore { get; set; } = new List<string> { "Bagatipara", "Baraigram", "Gurudaspur", "Lalpur", "Naldanga", "Natore Sadar", "Singra" };
    public List<string> Chapainawabganj { get; set; } = new List<string> { "Bholahat", "Gomastapur", "Nachole", "Nawabganj Sadar", "Shibganj" };
    public List<string> Pabna { get; set; } = new List<string> { "Atgharia", "Bera", "Bhangura", "Chatmohar", "Faridpur", "Ishwardi", "Pabna Sadar", "Santhia", "Sujanagar" };
    public List<string> Rajshahi { get; set; } = new List<string> { "Bagha", "Bagmara", "Charghat", "Durgapur", "Godagari", "Mohanpur", "Paba", "Puthia", "Tanore" };
    public List<string> Sirajganj { get; set; } = new List<string> { "Belkuchi", "Chauhali", "Kamarkhanda", "Kazipur", "Raiganj", "Shahjadpur", "Sirajganj Sadar", "Tarash", "Ullahpara" };
}


public class Barishal1
{
    public List<string> Barishal { get; set; } = new List<string> { "Agailjhara", "Babuganj", "Bakerganj", "Banaripara", "Barishal Sadar", "Gaurnadi", "Hizla", "Mehendiganj", "Muladi", "Wazirpur" };
    public List<string> Barguna { get; set; } = new List<string> { "Amtali", "Bamna", "Barguna Sadar", "Betagi", "Patharghata", "Taltali" };
    public List<string> Bhola { get; set; } = new List<string> { "Bhola Sadar", "Burhanuddin", "Char Fasson", "Daulatkhan", "Lalmohan", "Manpura", "Tazumuddin" };
    public List<string> Jhalokathi { get; set; } = new List<string> { "Jhalokathi Sadar", "Kathalia", "Nalchity", "Rajapur" };
    public List<string> Patuakhali { get; set; } = new List<string> { "Bauphal", "Dashmina", "Galachipa", "Kalapara", "Mirzaganj", "Patuakhali Sadar", "Rangabali" };
    public List<string> Pirojpur { get; set; } = new List<string> { "Bhandaria", "Kawkhali", "Mathbaria", "Nazirpur", "Nesarabad (Swarupkathi)", "Pirojpur Sadar", "Zianagar" };
}
public class Sylhet1
{
    public List<string> Habiganj { get; set; } = new List<string> { "Ajmiriganj", "Bahubal", "Baniachang", "Chunarughat", "Habiganj Sadar", "Lakhai", "Madhabpur", "Nabiganj", "Shaistaganj" };
    public List<string> Moulvibazar { get; set; } = new List<string> { "Barlekha", "Juri", "Kamalganj", "Kulaura", "Moulvibazar Sadar", "Rajnagar", "Sreemangal" };
    public List<string> Sunamganj { get; set; } = new List<string> { "Bishwamvarpur", "Chhatak", "Dakshin Sunamganj", "Derai", "Dharampasha", "Dowarabazar", "Jagannathpur", "Jamalganj", "Sullah", "Sunamganj Sadar", "Tahirpur" };
    public List<string> Sylhet { get; set; } = new List<string> { "Balaganj", "Beanibazar", "Bishwanath", "Companiganj", "Dakshin Surma", "Fenchuganj", "Golapganj", "Gowainghat", "Jaintiapur", "Kanaighat", "Osmaninagar", "Sylhet Sadar" };
}


public class Rangpur1
{
    public List<string> Dinajpur { get; set; } = new List<string> { "Birampur", "Birganj", "Biral", "Bochaganj", "Chirirbandar", "Dinajpur Sadar", "Ghoraghat", "Hakimpur", "Kaharole", "Khansama", "Nawabganj", "Parbatipur" };
    public List<string> Gaibandha { get; set; } = new List<string> { "Fulchhari", "Gaibandha Sadar", "Gobindaganj", "Palashbari", "Sadullapur", "Saghata", "Sundarganj" };
    public List<string> Kurigram { get; set; } = new List<string> { "Bhurungamari", "Char Rajibpur", "Chilmari", "Kurigram Sadar", "Nageshwari", "Phulbari", "Rajarhat", "Raomari", "Ulipur" };
    public List<string> Lalmonirhat { get; set; } = new List<string> { "Aditmari", "Hatibandha", "Kaliganj", "Lalmonirhat Sadar", "Patgram" };
    public List<string> Nilphamari { get; set; } = new List<string> { "Dimla", "Domar", "Jaldhaka", "Kishoreganj", "Nilphamari Sadar", "Saidpur" };
    public List<string> Panchagarh { get; set; } = new List<string> { "Atwari", "Boda", "Debiganj", "Panchagarh Sadar", "Tetulia" };
    public List<string> Rangpur { get; set; } = new List<string> { "Badarganj", "Gangachara", "Kaunia", "Mithapukur", "Pirgachha", "Rangpur Sadar", "Taraganj" };
    public List<string> Thakurgaon { get; set; } = new List<string> { "Baliadangi", "Haripur", "Pirganj", "Ranisankail", "Thakurgaon Sadar" };
}

public class Mymensingh1
{
    public List<string> Jamalpur { get; set; } = new List<string> { "Baksiganj", "Dewanganj", "Islampur", "Jamalpur Sadar", "Madarganj", "Melandaha", "Sarishabari" };
    public List<string> Mymensingh { get; set; } = new List<string> { "Bhaluka", "Dhobaura", "Fulbaria", "Gaffargaon", "Gauripur", "Haluaghat", "Ishwarganj", "Mymensingh Sadar", "Muktagachha", "Nandail", "Phulpur", "Trishal" };
    public List<string> Netrokona { get; set; } = new List<string> { "Atpara", "Barhatta", "Durgapur", "Kalmakanda", "Kendua", "Khaliajuri", "Madan", "Mohanganj", "Netrokona Sadar", "Purbadhala" };
    public List<string> Sherpur { get; set; } = new List<string> { "Jhenaigati", "Nakla", "Nalitabari", "Sherpur Sadar", "Sreebardi" };
}
