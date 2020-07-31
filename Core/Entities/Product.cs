namespace Core.Entities
{
    public class Product: BaseEntity
    {   
        public string Name { get; set; }
        public string Description{get;set;}
        public decimal Price{get;set;}
        public string PictureUrl{get;set;}
        public ProductType ProductType{get;set;} // to let entity framework knows that product 
        public int ProductTypeId{get;set;}//has a relationship with product and id act as foreign keys
        public ProductBrand ProductBrand{get;set;}
        public int ProductBrandId{get;set;}

    }
}