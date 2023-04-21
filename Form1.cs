using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using лр1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace лр1
{
    public partial class Form1 : Form
    {
        //создание списка для визуализации всех загруженных пользователем изображениий
        List<ImageInfo> images = new List<ImageInfo>();
        //выходное изображение
        ImageInfo outImage = new ImageInfo();
        public int nowTag = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //функция инициализация кнопки ввода
        //!!!!!!!!!!!!!!!добавить возможность перетаскивать слои
        //и маски
        private void LayoutAdd(int tag)
        {
            var layoutPanel = new Panel();
            var closeButton = new Button();
            var transparencyLayoutLabel = new Label();
            var effectsLayoutLabel = new Label();
            var nameLayoutLabel = new Label();
            var pictureBox1 = new PictureBox();

            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();

            layoutPanel.Controls.Add(effectsLayoutLabel);
            layoutPanel.Controls.Add(transparencyLayoutLabel);
            layoutPanel.Controls.Add(closeButton);
            layoutPanel.Controls.Add(nameLayoutLabel);
            layoutPanel.Controls.Add(pictureBox1);
            ///
            /// effectsLayoutLabel
            ///
            effectsLayoutLabel.AutoSize = true;
            effectsLayoutLabel.Size = new System.Drawing.Size(61, 16);
            effectsLayoutLabel.Text = "Эффект: Нет";
            effectsLayoutLabel.Location = new System.Drawing.Point(111, 42);
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Size = new System.Drawing.Size(102, 93);
            pictureBox1.TabStop = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //добавление картинки
            try
            {
                pictureBox1.Image = images[tag-1].bitmap;
                pictureBox1.Invalidate();
            }
            catch
            {
                DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 
            // nameLayoutLabel
            // 
            nameLayoutLabel.AutoSize = true;
            nameLayoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            nameLayoutLabel.Location = new System.Drawing.Point(111, 8);
            nameLayoutLabel.Size = new System.Drawing.Size(65, 20);
            nameLayoutLabel.Text = "Слой " + tag.ToString();
            // 
            // closeButton
            // 
            closeButton.Location = new System.Drawing.Point(230, 0);
            closeButton.Size = new System.Drawing.Size(29, 28);
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = true;
            // 
            // transparencyLayoutLabel
            // 
            transparencyLayoutLabel.AutoSize = true;
            transparencyLayoutLabel.Location = new System.Drawing.Point(111, 71);
            transparencyLayoutLabel.Size = new System.Drawing.Size(108, 16);
            transparencyLayoutLabel.Text = "Прозрачность: 100%";

            layoutPanel.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();

            layoutPanel.Size = new System.Drawing.Size(270, 99);
            layoutPanel.Tag = tag;
            //убрать все выделения
            foreach (Panel panel in layoutGroupPanel.Controls)
                panel.BorderStyle = BorderStyle.None;
            //и добавить выделение на нынешний
            layoutPanel.BorderStyle = BorderStyle.FixedSingle;



            //добавить клик на панель
            layoutPanel.Click += new System.EventHandler(LayoutPanel_Click);
            //кнопка закрытия
            closeButton.Click+= new System.EventHandler(CloseLayerButton_Click);
            //добавление новой панели 
            layoutGroupPanel.Controls.Add(layoutPanel);

            //изменение переключения слой
            nowTag = tag-1;
            transparencyBar.Value = 255;
            effectsBox.SelectedIndex = 0;
        }

        //функция для обновления изображения на форме
        public void UpdateForm()
        {
            //высчитать максимальную высоту и длинну картинки
            outImage.bitmap = new Bitmap(images.Max(img => img.bitmap.Width), images.Max(img => img.bitmap.Height));
            //заполнение белым outImage
            for (int i = 0; i < outImage.bitmap.Width; i++) //а тут с нулевого или первого пикселя?
                for (int j = 0; j < outImage.bitmap.Height; j++)
                    outImage.bitmap.SetPixel(i, j, Color.White);
            
            //пересчет слоев
            foreach (ImageInfo img in images)
                 outImage.bitmap = outImage.EffectAdder(img);
            //просто вывод изображения
            pictureBox.Image = (System.Drawing.Image)outImage.bitmap;
        }


        //===================================работа с файлами
        //кнопка "сохранить изображение"
        private void SaveButton_Click(object sender, EventArgs e)
        {
            
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Сохранение изображения";
                    saveDialog.DefaultExt = "*.png";
                    saveDialog.Filter = "Файлы изображений |*.bmp;*.jpg;*.png";
                    saveDialog.InitialDirectory = @"C:\";
                    if (saveDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    if(outImage.bitmap != null)
                        outImage.bitmap.Save(saveDialog.FileName);
                    else
                        MessageBox.Show("Вы думали, я вас не переиграю? Не уничтожу? Я вас уничтожу.");
                }
            
            
        }
        //кнопка "добавить изображение" 
        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var theDialog = new OpenFileDialog())
            {
                //открытие изображения пользователем
                theDialog.Title = "Открытие изображения";
                theDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    //добавление слоя в лист слоев
                    ImageInfo newImageInfo = new ImageInfo(new Bitmap(System.Drawing.Image.FromFile(theDialog.FileName)));
                    images.Add(newImageInfo);
                    //добавление слоя в панель
                    LayoutAdd(images.Count);
                    //обновление формы
                    UpdateForm();
                }
            }
        }

        //====================================работа с меню
        //!!!!!!!!!!!изменение значения прозрачности
        private void TransparencyBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                images[nowTag].transparency = transparencyBar.Value;
                //нужно добавить отображение на слое в панели со слоями (и перенести это в эффекты)
                //layoutGroupPanel.Controls.
                UpdateForm();
            }
            catch
            {
                transparencyBar.Value = 0;
                MessageBox.Show("ВЫ НЕ ДАЖЕ ПЫТАЛИСЬ ДОБАВИТЬ СЛОЙ! (да, это еще одно агрессивное сообщение об ошибке)");
            }
        }
        //функция для изменения наложения выделенного слоя
        private void EffectsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                images[nowTag].overlay = effectsBox.SelectedItem.ToString();
                UpdateForm();
            }
            catch
            {
                effectsBox.SelectedItem = null;
                MessageBox.Show("ВЫ НЕ ДОБАВИЛИ СЛОЙ! (да, это агрессивные сообщения об ошибке)");
            }
        }

        //====================================работа со слоями
        //изменение выделенного слоя
        private void LayoutPanel_Click(object sender, EventArgs e)
        {
            //убрать все выделения
            foreach (Panel panel in layoutGroupPanel.Controls)
                panel.BorderStyle = BorderStyle.None;
            //к какому слою обращение?
            nowTag = (int)((Panel)sender).Tag - 1;
            //установление прозрачности
            transparencyBar.Value = images[nowTag].transparency;
            //установление эффекта слоя
            effectsBox.SelectedIndex = effectsBox.Items.IndexOf(images[nowTag].overlay);
            //установление выделения
            ((Panel)sender).BorderStyle = BorderStyle.FixedSingle;
        }
        //!!!!!!!!!!!!!!!!!закрытие слоя
        private void CloseLayerButton_Click(object sender, EventArgs e)
        {
            try
            {
                //на какой слой нажали
                //посмотри, нажимают на кнопку, а удалить надо панель
                var tag = (int)((Button)sender).Parent.Tag;
                //удаление контрола (панельки и слоя из списка)
                (sender as Button).Parent.Dispose();
                //удаление картинки из внутреннего списка
                images.RemoveAt(tag-1);
                //пробежаться по всем контролам layoutGroupControl и изменить тег на -1
                for(tag -= 1; tag < layoutGroupPanel.Controls.Count; tag++)
                {
                    layoutGroupPanel.Controls[tag].Tag = tag;
                }
                UpdateForm();
            }
            catch {
                MessageBox.Show("Эта функция еще не работает");
            }
        }
    }
}
