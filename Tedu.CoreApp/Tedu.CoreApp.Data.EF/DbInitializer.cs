using Microsoft.AspNetCore.Identity;
using Tedu.CoreApp.Data.EF;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Data.Entities.System;
using Tedu.CoreApp.Data;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Utilities.Constants;
using Tedu.CoreApp.Data.Enums;


namespace TeduCore.Data.EF;

public class DbInitializer
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public DbInitializer(AppDbContext context,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task Seed()
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        var rootAdminRoleId = Guid.NewGuid();
        if (!_context.Roles.Any())
        {
            await _roleManager.CreateAsync(new AppRole()
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "Quản trị viên"
            });
            await _roleManager.CreateAsync(new AppRole()
            {
                Name = "Staff",
                NormalizedName = "Staff",
                Description = "Nhân viên"
            });
            await _roleManager.CreateAsync(new AppRole()
            {
                Name = "Customer",
                NormalizedName = "Customer",
                Description = "Khách hàng"
            });
        }
        if (!_userManager.Users.Any())
        {
            await _userManager.CreateAsync(new AppUser()
            {
                UserName = "admin",
                FullName = "Administrator",
                Email = "admin@gmail.com",
                Balance = 0,
                Avatar = "/client-side/images/user.png",
                Status = Status.Actived,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            }, "123456");
            var user = await _userManager.FindByNameAsync("admin");
            await _userManager.AddToRoleAsync(user, "Admin");
            await _context.SaveChangesAsync();
        }

        if (!_context.Functions.Any())
        {
            var functionId = Guid.NewGuid();
            var ecommerceId = Guid.NewGuid();
            var contentId = Guid.NewGuid();
            var utilityId = Guid.NewGuid();
            var reportId = Guid.NewGuid();
            _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id =functionId,UniqueCode = "SYSTEM", Name = "Hệ thống",ParentId = null,SortOrder = 1,Status = Status.Actived,Url = "/",CssClass = "fa-desktop"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ROLE", Name = "Nhóm",ParentId = functionId,SortOrder = 1,Status = Status.Actived,Url = "/admin/role/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FUNCTION", Name = "Chức năng",ParentId = functionId,SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FUNCTION", Name = "Chức năng",ParentId = functionId,SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FUNCTION", Name = "Chức năng",ParentId = functionId,SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "USER", Name = "Người dùng",ParentId = functionId,SortOrder =3,Status = Status.Actived,Url = "/admin/user/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ACTIVITY", Name = "Nhật ký",ParentId = functionId,SortOrder = 4,Status = Status.Actived,Url = "/admin/activity/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ERROR", Name = "Lỗi",ParentId = functionId,SortOrder = 5,Status = Status.Actived,Url = "/admin/error/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "SETTING", Name = "Cấu hình",ParentId = functionId,SortOrder = 6,Status = Status.Actived,Url = "/admin/setting/index",CssClass = "fa-home"  },

                    new Function() {Id =ecommerceId,UniqueCode = "ECOMMERCE",Name = "Sản phẩm",ParentId = null,SortOrder = 2,Status = Status.Actived,Url = "/",CssClass = "fa-chevron-down"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "PRODUCT_CATEGORY",Name = "Danh mục",ParentId = ecommerceId,SortOrder =1,Status = Status.Actived,Url = "/admin/productcategory/index",CssClass = "fa-chevron-down"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "PRODUCT_LIST",Name = "Sản phẩm",ParentId = ecommerceId,SortOrder = 2,Status = Status.Actived,Url = "/admin/product/index",CssClass = "fa-chevron-down"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "BILL",Name = "Hóa đơn",ParentId = ecommerceId,SortOrder = 3,Status = Status.Actived,Url = "/admin/bill/index",CssClass = "fa-chevron-down"  },

                    new Function() {Id =contentId,UniqueCode = "CONTENT",Name = "Nội dung",ParentId = null,SortOrder = 3,Status = Status.Actived,Url = "/",CssClass = "fa-table"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "BLOG",Name = "Bài viết",ParentId =contentId,SortOrder = 1,Status = Status.Actived,Url = "/admin/blog/index",CssClass = "fa-table"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "PAGE",Name = "Trang",ParentId = contentId,SortOrder = 2,Status = Status.Actived,Url = "/admin/page/index",CssClass = "fa-table"  },

                    new Function() {Id =utilityId,UniqueCode = "UTILITY",Name = "Tiện ích",ParentId = null,SortOrder = 4,Status = Status.Actived,Url = "/",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FOOTER",Name = "Footer",ParentId = utilityId,SortOrder = 1,Status = Status.Actived,Url = "/admin/footer/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FEEDBACK",Name = "Phản hồi",ParentId = utilityId,SortOrder = 2,Status = Status.Actived,Url = "/admin/feedback/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ANNOUNCEMENT",Name = "Thông báo",ParentId = utilityId,SortOrder = 3,Status = Status.Actived,Url = "/admin/announcement/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "CONTACT",Name = "Liên hệ",ParentId = utilityId,SortOrder = 4,Status = Status.Actived,Url = "/admin/contact/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "SLIDE",Name = "Slide",ParentId = utilityId,SortOrder = 5,Status = Status.Actived,Url = "/admin/slide/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ADVERTISMENT",Name = "Quảng cáo",ParentId = utilityId,SortOrder = 6,Status = Status.Actived,Url = "/admin/advertistment/index",CssClass = "fa-clone"  },

                    new Function() {Id =reportId,UniqueCode = "REPORT",Name = "Báo cáo",ParentId = null,SortOrder = 5,Status = Status.Actived,Url = "/",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "REVENUES",Name = "Báo cáo doanh thu",ParentId = reportId,SortOrder = 1,Status = Status.Actived,Url = "/admin/report/revenues",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ACCESS",Name = "Báo cáo truy cập",ParentId = reportId,SortOrder = 2,Status = Status.Actived,Url = "/admin/report/visitor",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "READER",Name = "Báo cáo độc giả",ParentId = reportId,SortOrder = 3,Status = Status.Actived,Url = "/admin/report/reader",CssClass = "fa-bar-chart-o"  },
                });
        }

        if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
        {
            string content = "Footer";
            _context.Footers.Add(new Footer()
            {
                Id = CommonConstants.DefaultFooterId,
                Content = content
            });
        }
        if (_context.ContactDetails.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
        {
            _context.ContactDetails.Add(new ContactDetail()
            {
                Id = CommonConstants.DefaultFooterId,
                Name = "Panda Shop",
                Status = Status.Actived,
                Address = "Số 36 ngõ 133 Nguyễn Phong Sắc Cầu Giấy Hà Nội",
                Email = "nguyenthanhhuong.hailong@gmail.com",
                Phone = "0962 370 186",
                Website = "http://phukientrangsucnu.com",
                Lng = 21.0435483,
                Lat = 105.790058,
            });
        }

        if (!_context.AdvertistmentPages.Any())
        {
            List<AdvertistmentPage> pages = new List<AdvertistmentPage>()
                {
                    new AdvertistmentPage() { Id = Guid.NewGuid(), UniqueCode="home", Name="Trang chủ"},
                    new AdvertistmentPage() { Id =Guid.NewGuid(), UniqueCode ="product-cate", Name="Danh mục sản phẩm" },
                    new AdvertistmentPage() { Id = Guid.NewGuid(), UniqueCode ="product-detail", Name="Chi tiết sản phẩm"},
                };
            _context.AdvertistmentPages.AddRange(pages);
        }

        if (!_context.Slides.Any())
        {
            List<Slide> slides = new List<Slide>()
                {
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 1",Image="/client-side/images/slider/slide-1.jpg",Url="#",DisplayOrder = 0,GroupAlias = SlideGroup.Top, },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 2",Image="/client-side/images/slider/slide-2.jpg",Url="#",DisplayOrder = 1,GroupAlias = SlideGroup.Top,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 3",Image="/client-side/images/slider/slide-3.jpg",Url="#",DisplayOrder = 2,GroupAlias = SlideGroup.Top,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 1",Image="/client-side/images/brand1.png",Url="#",DisplayOrder = 1,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 2",Image="/client-side/images/brand2.png",Url="#",DisplayOrder = 2,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 3",Image="/client-side/images/brand3.png",Url="#",DisplayOrder = 3,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 4",Image="/client-side/images/brand4.png",Url="#",DisplayOrder = 4,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 5",Image="/client-side/images/brand5.png",Url="#",DisplayOrder = 5,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 6",Image="/client-side/images/brand6.png",Url="#",DisplayOrder = 6,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 7",Image="/client-side/images/brand7.png",Url="#",DisplayOrder = 7,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 8",Image="/client-side/images/brand8.png",Url="#",DisplayOrder = 8,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 9",Image="/client-side/images/brand9.png",Url="#",DisplayOrder = 9,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 10",Image="/client-side/images/brand10.png",Url="#",DisplayOrder = 10,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 11",Image="/client-side/images/brand11.png",Url="#",DisplayOrder = 11,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                };
            _context.Slides.AddRange(slides);
        }

        if (!_context.ProductCategories.Any())
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();
            var id4 = Guid.NewGuid();
            List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Id = Guid.NewGuid(), Name="Áo nam",SeoAlias="ao-nam",ParentId = null,Status=Status.Actived,SortOrder=1, Description="Áo nam"},
                    new ProductCategory() { Id = Guid.NewGuid(), Name="Áo nữ",SeoAlias="ao-nu",ParentId = null,Status=Status.Actived ,SortOrder=2, Description="Áo nữ"},
                    new ProductCategory() { Id = Guid.NewGuid(), Name="Giày nam",SeoAlias="giay-nam",ParentId = null,Status=Status.Actived ,SortOrder=3, Description="Giày nam"},
                    new ProductCategory() { Id = Guid.NewGuid(), Name="Giày nữ",SeoAlias="giay-nu",ParentId = null,Status=Status.Actived,SortOrder=4, Description="Giày nữ"},
                };
            var list1 = new List<Product>()
                        {
                            new Product(){CategoryId = id1, Name = "Sản phẩm 11",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-11",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1,Name = "Sản phẩm 12",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-12",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1,Name = "Sản phẩm 13",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-13",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1,Name = "Sản phẩm 14",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-14",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1,Name = "Sản phẩm 15",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-15",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
            var list2 = new List<Product>()
                        {
                            new Product(){CategoryId = id2,Name = "Sản phẩm 6",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-6",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2,Name = "Sản phẩm 7",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-7",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2,Name = "Sản phẩm 8",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-8",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2,Name = "Sản phẩm 9",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-9",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2,Name = "Sản phẩm 10",ThumbnailImage="/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-10",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
            var list3 = new List<Product>()
                        {
                            new Product() {CategoryId = id3, Name = "Sản phẩm 1",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-1",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() {CategoryId = id3, Name = "Sản phẩm 2",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-2",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() {CategoryId = id3, Name = "Sản phẩm 3",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-3",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() {CategoryId = id3, Name = "Sản phẩm 4",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-4",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() {CategoryId = id3, Name = "Sản phẩm 5",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-5",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
            var list4 = new List<Product>()
                        {
                            new Product() { CategoryId = id4,Name = "Sản phẩm 16",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-16",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() { CategoryId = id4,Name = "Sản phẩm 17",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-17",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() { CategoryId = id4,Name = "Sản phẩm 18",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-18",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() { CategoryId = id4,Name = "Sản phẩm 19",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-19",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product() { CategoryId = id4,Name = "Sản phẩm 20",ThumbnailImage = "/client-side/images/products/product-1.jpg",SeoAlias = "san-pham-20",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };

            _context.ProductCategories.AddRange(listProductCategory);
            _context.Products.AddRange(list1);
            _context.Products.AddRange(list2);
            _context.Products.AddRange(list3);
            _context.Products.AddRange(list4);
        }

        if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeTitle"))
        {
            _context.SystemConfigs.Add(new Setting()
            {
                Id = Guid.NewGuid(),
                UniqueCode = "HomeTitle",
                Name = "Tiêu đề trang chủ",
                TextValue = "Trang chủ TeduShop",
                Status = Status.Actived
            });
        }
        if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeMetaKeyword"))
        {
            _context.SystemConfigs.Add(new Setting()
            {
                Id = Guid.NewGuid(),
                UniqueCode = "HomeMetaKeyword",
                Name = "Từ khoá trang chủ",
                TextValue = "Trang chủ TeduShop",
                Status = Status.Actived
            });
        }
        if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeMetaDescription"))
        {
            _context.SystemConfigs.Add(new Setting()
            {
                Id = Guid.NewGuid(),
                UniqueCode = "HomeMetaDescription",
                Name = "Mô tả trang chủ",
                TextValue = "Trang chủ TeduShop",
                Status = Status.Actived
            });
        }
        await _context.SaveChangesAsync();
    }
}
