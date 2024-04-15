using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        static bool IsInRange(Tuple<int, int> temperatureRange, double temperature)
        {
            return temperature >= temperatureRange.Item1 && temperature <= temperatureRange.Item2;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            if (!radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                textBox1.Text = "Выберите повод!";
                return;
            }
            int temperature = trackBar1.Value;//Температура

            bool isPrecipitation = radioButton1.Checked;//Осадки
            bool snowRain;
            string Precipitation = "Без осадков";
            if (isPrecipitation)
            {
                snowRain = (temperature < 0) && isPrecipitation;
                if (snowRain)
                    Precipitation = "Снег";
                else
                    Precipitation = "Дождь";
            }
            //Повод
            string occasion;
            if (radioButton3.Checked)
                occasion = "Деловой";
            else if (radioButton2.Checked)
                occasion = "Повседневный";
            else
                occasion = "Спорт";


            // Рекомендации по одежде
            List<Clothes> clothesList = new List<Clothes>
            {
                new Clothes("Шапка утепленная", "Головной убор", new Tuple<int, int>(-40, -10),new List<string>{"Повседневный", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Шапка", "Головной убор", new Tuple<int, int>(-15, 7),new List<string>{"Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Шапка-ушанка с натуральным мехом", "Головной убор", new Tuple<int, int>(-40, 0),new List<string>{"Повседневный", "Деловой" }, new List<string>{ "Снег", "Без осадков" }),
                new Clothes("Теплый свитер", "Верхняя 1 слой", new Tuple<int, int>(10, 18), new List<string>{"Повседневный", "Деловой" }, new List<string>{ "Без осадков" }),
                new Clothes("Куртка утепленная", "Верхняя 2 слой", new Tuple<int, int>(-40, 5), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Термоштаны", "Нижняя 2 слой", new Tuple<int, int>(-40, 5), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Термокофта", "Верхняя 1 слой", new Tuple<int, int>(5, 18), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Футболка", "Верхняя 1 слой", new Tuple<int, int>(20, 40), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Без осадков" }),
                new Clothes("Футболка-поло", "Верхняя 1 слой", new Tuple<int, int>(20, 40), new List<string>{ "Повседневный", "Деловой"}, new List < string > { "Без осадков" }),
                new Clothes("Рубашка с коротким рукавом", "Верхняя 1 слой", new Tuple<int, int>(20, 40), new List<string>{ "Повседневный", "Деловой"}, new List<string>{ "Без осадков" }),
                new Clothes("Рубашка с длинным рукавом", "Верхняя 1 слой", new Tuple<int, int>(20, 25), new List<string>{ "Повседневный", "Деловой"}, new List<string>{ "Без осадков" }),
                new Clothes("Шорты", "Нижняя 1 слой", new Tuple<int, int>(15, 40), new List<string>{ "Повседневный", "Спорт" }, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Шорты джинсовые", "Нижняя 1 слой", new Tuple<int, int>(15, 40), new List<string>{ "Повседневный", "Деловой"}, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Джинсы", "Нижняя 1 слой", new Tuple<int, int>(-30, 25), new List<string>{ "Повседневный", "Деловой", }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Джинсы утепленные", "Нижняя 1 слой", new Tuple<int, int>(-40, -5), new List<string>{ "Повседневный", "Деловой", }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Брюки спортивные утепленные", "Нижняя 1 слой", new Tuple<int, int>(-40, 25), new List<string>{ "Повседневный", "Спорт", }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Брюки", "Нижняя 1 слой", new Tuple<int, int>(-30, 25), new List<string>{ "Деловой"}, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Брюки спортивные", "Нижняя 1 слой", new Tuple<int, int>(-30, 20), new List<string>{ "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Ботинки утепленные", "Обувь", new Tuple<int, int>(-20, 5), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Зонт", "Аксессуар", new Tuple<int, int>(5, 40), new List<string>{ "Повседневный", "Деловой" }, new List<string>{ "Дождь" }),
                new Clothes("Перчатки", "Аксессуар", new Tuple<int, int>(-20, 5), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Перчатки кожаные", "Аксессуар", new Tuple<int, int>(-20, 5), new List<string>{ "Деловой"}, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Варежки  Regular", "Аксессуар", new Tuple<int, int>(-40, 0), new List<string>{ "Повседневный", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Варежки  Premium", "Аксессуар", new Tuple<int, int>(-40, 0), new List<string>{ "Повседневный", "Деловой"}, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Легкая куртка", "Верхняя 2 слой", new Tuple<int, int>(5, 15), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Без осадков" }),
                new Clothes("Дождевик", "Верхняя 2 слой", new Tuple<int, int>(5, 40), new List<string>{ "Повседневный", "Деловой", "Спорт" }, new List<string>{ "Дождь", "Снег"}),
                new Clothes("Кроссовки утепленные", "Обувь", new Tuple<int, int>(-5, 15), new List<string>{ "Повседневный", "Спорт" }, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Кроссовки", "Обувь", new Tuple<int, int>(10, 25), new List<string>{ "Повседневный", "Спорт" }, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Сандалии", "Обувь", new Tuple<int, int>(20, 40), new List<string>{ "Повседневный", "Спорт" }, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Сандалии кожаные", "Обувь", new Tuple<int, int>(20, 40), new List<string>{ "Повседневный", "Деловой" }, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Сланцы", "Обувь", new Tuple<int, int>(20, 40), new List<string>{ "Повседневный", "Спорт" }, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Валенки", "Обувь", new Tuple<int, int>(-40, -5), new List<string>{ "Повседневный"}, new List<string>{ "Снег", "Без осадков" }),
                new Clothes("Туфли кожаные", "Обувь", new Tuple<int, int>(10, 25), new List<string>{ "Деловой"}, new List<string>{ "Дождь", "Без осадков" }),
                new Clothes("Кепка", "Головной убор", new Tuple<int, int>(15, 40), new List<string>{ "Спорт", "Повседневный"}, new List<string>{ "Без осадков" }),
                new Clothes("Шляпа", "Головной убор", new Tuple<int, int>(15, 25), new List<string>{ "Деловой"}, new List < string > { "Без осадков" }),
                new Clothes("Ботинки кожаные утепленные", "Обувь", new Tuple<int, int>(-40, 5), new List<string>{ "Повседневный", "Деловой"}, new List<string>{ "Дождь", "Снег", "Без осадков" }),
                new Clothes("Ботинки спортивные утепленные", "Обувь", new Tuple<int, int>(-40, 5), new List<string>{ "Повседневный", "Спорт"}, new List<string>{ "Дождь", "Снег", "Без осадков" }),

            };
            
            // Фильтрация списка по критериям пользователя
            int houseTemp = temperature;    
            if (temperature < 10 && temperature > -5)
            {
                houseTemp = 25;
            }
            else if (temperature <= -5)
            {
                houseTemp = 15;
            }
            var filteredHeadwear = clothesList.Where(c => IsInRange(c.TemperatureRange, temperature) && c.Occasion.Contains(occasion) && c.Type == "Головной убор" && c.Precipitation.Contains(Precipitation));
            var filteredUpperPrimaryLayer = clothesList.Where(c => IsInRange(c.TemperatureRange, houseTemp) && c.Occasion.Contains(occasion) && c.Type == "Верхняя 1 слой");
            var filteredUpperSecondLayer = clothesList.Where(c => IsInRange(c.TemperatureRange, temperature) && c.Occasion.Contains(occasion) && c.Type == "Верхняя 2 слой" && c.Precipitation.Contains(Precipitation));
            var filteredLowerPrimaryLayer = clothesList.Where(c => IsInRange(c.TemperatureRange, temperature) && c.Occasion.Contains(occasion) && c.Type == "Нижняя 1 слой" && c.Precipitation.Contains(Precipitation));
            var filteredLowerSecondLayer = clothesList.Where(c => IsInRange(c.TemperatureRange, temperature) && c.Occasion.Contains(occasion) && c.Type == "Нижняя 2 слой" && c.Precipitation.Contains(Precipitation));
            var filteredFootwear = clothesList.Where(c => IsInRange(c.TemperatureRange, temperature) && c.Occasion.Contains(occasion) && c.Type == "Обувь" && c.Precipitation.Contains(Precipitation));
            var filteredAccessories = clothesList.Where(c => IsInRange(c.TemperatureRange, temperature) && c.Occasion.Contains(occasion) && c.Type == "Аксессуар" && c.Precipitation.Contains(Precipitation));


            // Дополнительные условия для комбинированных вариантов
            string delimiter = " ИЛИ ";
            foreach (var clo in filteredHeadwear)
            {
                textBox1.Text += clo + delimiter;
            }
            foreach (var clo in filteredUpperPrimaryLayer)
            {
                textBox2.Text += clo + delimiter;
            }
            foreach (var clo in filteredUpperSecondLayer)
            {
                textBox3.Text += clo + delimiter;
            }
            foreach (var clo in filteredLowerPrimaryLayer)
            {
                textBox4.Text += clo + delimiter;
            }
            foreach (var clo in filteredLowerSecondLayer)
            {
                textBox5.Text += clo + delimiter;
            }
            foreach (var clo in filteredFootwear)
            {
                textBox6.Text += clo + delimiter;
            }
            foreach (var clo in filteredAccessories)
            {
                textBox7.Text += clo + delimiter;
            }

            int index = textBox1.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox1.Text = textBox1.Text.Remove(index, delimiter.Length);
            }
            index = textBox2.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox2.Text = textBox2.Text.Remove(index, delimiter.Length);
            }
            index = textBox3.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox3.Text = textBox3.Text.Remove(index, delimiter.Length);
            }
            index = textBox4.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox4.Text = textBox4.Text.Remove(index, delimiter.Length);
            }
            index = textBox5.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox5.Text = textBox5.Text.Remove(index, delimiter.Length);
            }
            index = textBox6.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox6.Text = textBox6.Text.Remove(index, delimiter.Length);
            }
            index = textBox7.Text.LastIndexOf(delimiter);
            if (index != -1)
            {
                textBox7.Text = textBox7.Text.Remove(index, delimiter.Length);
            }
            if (textBox1.Text == "")
                textBox1.Text = "Нет подходящей одежды";
            if (textBox2.Text == "")
                textBox2.Text = "Нет подходящей одежды";
            if (textBox3.Text == "")
                textBox3.Text = "Нет подходящей одежды";
            if (textBox4.Text == "")
                textBox4.Text = "Нет подходящей одежды";
            if (textBox5.Text == "")
                textBox5.Text = "Нет подходящей одежды";
            if (textBox6.Text == "")
                textBox6.Text = "Нет подходящей одежды";
            if (textBox7.Text == "")
                textBox7.Text = "Нет подходящей одежды";

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label8.Text = trackBar1.Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
