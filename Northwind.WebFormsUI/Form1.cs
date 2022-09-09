using Northwind.Busi.Abstract;
using Northwind.Busi.Concrete;
using Northwind.Busi.DependencyResolvers.ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using Northwind.WebFormsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
         
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //ProductManager _productManager = new ProductManager(new EfProductDal());
        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();

        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll().ToList();
            // GÖRÜNÜN KISIM KATEGORİNİN İSMİ- SEÇTİĞİMİZDE IDSİ OLSUN
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            // BİRDE ÜRÜN EKLENİRKEN KATEGORİLERİN YÜKLENMESİ
            cbxCategoryId.DataSource = _categoryService.GetAll().ToList();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";

            // GÜNCELLEME KISMINDA KATEGORİLERİN YÜKLENMESİ
            cbxUpdateCategory.DataSource = _categoryService.GetAll().ToList();
            cbxUpdateCategory.DisplayMember = "CategoryName";
            cbxUpdateCategory.ValueMember = "CategoryId";

        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void gbxCategory_Enter(object sender, EventArgs e)
        {

        }

        private void gbxSearch_Enter(object sender, EventArgs e)
        {

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // YÜKLEME ESNASINDA HATA ALMAMAK İÇİN OLUŞTURDUM
            try
            {
                // SEÇİLEN KATEGORİYE GÖRE ÜRÜN Nİ GETİRME
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));

            }
            catch
            {

                
            }
           

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Textboxta boş değilse, İLGİLİ ID GÖRE LİSTELE
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);

            }
            // BOŞ İSE TÜM LİSTEYİ GÖSTER
            else
            {
                LoadProducts();
            }

        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row= dgwProduct.CurrentRow;
            tbxUpdateName.Text = row.Cells[1].Value.ToString();
            tbxUpdatePrice.Text = row.Cells[3].Value.ToString();
            cbxUpdateCategory.SelectedValue = row.Cells[2].Value;
            tbxUpdateStockAmount.Text = row.Cells[5].Value.ToString();
            tbxUpdateStockPerUnit.Text = row.Cells[4].Value.ToString();   
           
        }

        private void gbxProductAdd_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {
                _productService.Add(new Product
                {
                    // BUTONA TIKLADIĞIMDA YAZILAN BİLGİLERİ EKRANA GÖNDERECEK
                    // Add isminde Metod Oluştur F12 ile ilgili yer git gerekli işlemleri yap
                    // Yazılan Bilgileri Buraya Çekmem Lazım

                    CategoryID = Convert.ToInt32(cbxCategoryId.SelectedValue),
                    ProductName = tbxProductName2.Text,
                    QuantityPerUnit = tbxStockPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(tbxProductPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxStockAmount.Text)

                });
                MessageBox.Show("ÜRÜNLER KAYDEDİLDİ !");
                LoadProducts();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                // SEÇİLİ ID ALACAZ ONUN ÜZERİNDEN İŞLEM YAPACAĞIZ
                ProductID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                CategoryID = Convert.ToInt32(cbxUpdateCategory.SelectedValue),
                ProductName = tbxUpdateName.Text,
                QuantityPerUnit = tbxUpdateStockPerUnit.Text, 
                UnitPrice = Convert.ToDecimal(tbxUpdatePrice.Text),
                UnitsInStock = Convert.ToInt16(tbxUpdateStockAmount.Text)

            });
            MessageBox.Show("ÜRÜNLER GÜNCELLENDİ!");
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Dgw Boş İken Silme Yapmasın-- YOksa Hata Alırz
            if (dgwProduct.CurrentRow !=null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("ÜRÜNLER SİLİNDİ!");
                    LoadProducts();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            


        }
    }
}
