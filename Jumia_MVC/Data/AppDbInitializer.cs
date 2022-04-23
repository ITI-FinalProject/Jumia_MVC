using FinalProject.MVC.Data.statics;
using Jumia_MVC.Data;
using Jumia_MVC.Models;
using Microsoft.AspNetCore.Identity;


namespace Movie_Application.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {


            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();

                //Category
                if (!context.Categorys.Any())
                {
                    context.Categorys.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "electrionic devices",
                            Image="https://student.valuxapps.com/storage/uploads/categories/16301438353uCFh.29118.jpg"
                        },
                      new Category()
                        {
                            Name = "Prevent Corona",
                            Image="https://student.valuxapps.com/storage/uploads/categories/1630142480dvQxx.3658058.jpg"
                        },
                       new Category()
                        {
                            Name = "sports",
                            Image="https://student.valuxapps.com/storage/uploads/categories/16445270619najK.6242655.jpg"
                        },
                        new Category()
                        {
                            Name = "Lighting",
                            Image="https://student.valuxapps.com/storage/uploads/categories/16445230161CiW8.Light bulb-amico.png"
                        },
                       new Category()
                        {
                            Name = "Clothes",
                            Image="https://student.valuxapps.com/storage/uploads/categories/1644527120pTGA7.clothes.png"
                        },
                    }); ;
                    context.SaveChanges();
                }

                //Banner
                if (!context.Banners.Any())
                {
                    context.Banners.AddRange(new List<Banner>()
                    {
                        new Banner()
                        {
                            Title = "Banner One",
                            SubTitle="Sup Title one",
                            Image="https://firebasestorage.googleapis.com/v0/b/ecommerce-59df3.appspot.com/o/apartment-architecture-carpet-276583.png?alt=media&token=dc774d17-7c3b-4749-8c74-50fd3ed50e8e"
                        },
                      new Banner()
                        {
                             Title = "Banner Two",
                            SubTitle="Sup Title Two",
                            Image="https://firebasestorage.googleapis.com/v0/b/ecommerce-59df3.appspot.com/o/joao-silas-SfkLX6fUObk-unsplash.png?alt=media&token=05dc6027-88a8-43f6-9d7e-bf4689153f80"
                        },
                  }); ;
                    context.SaveChanges();
                }


                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        //electorice
                        new Product()
                        {
                            Name = "Apple iPhone 12 Pro Max 256GB 6 GB RAM, Pacific Blue",
                            Old_Price=25000,
                            Price=25000,
                            Discount=0,
                            Quentity=3,
                            CategoryId=1,
                            Description="DISPLAY\r\nSize: 6.7 inches\r\nResolution: 2778 x 1284 pixels, 458 PPI\r\nTechnology: OLED\r\nScreen-to-body: 87.45 %\r\nPeak brightness: 1200 cd/m2 (nit)\r\nFeatures: HDR video support, Oleophobic coating, Scratch-resistant glass (Ceramic Shield), Ambient light sensor, Proximity sensor\r\nHARDWARE\r\nSystem chip: Apple A14 Bionic\r\nProcessor: Hexa-core, 64-bit, 5 nm\r\nGPU: Yes\r\nRAM: 6GB LPDDR5\r\nInternal storage: 128GB (NVMe), not expandable\r\nDevice type: Smartphone\r\nOS: iOS (14.x)\r\nBATTERY\r\nType: Li - Ion, Not user replaceable\r\nCharging: USB Power Delivery, Qi wireless charging, MagSafe wireless charging\r\nMax charge speed: Wireless: 15.0W\r\nCAMERA\r\nRear: Triple camera\r\nMain camera: 12 MP (OIS, PDAF)\r\nSpecifications: Aperture size: F1.6; Focal length: 26 mm; Pixel size: 1.7 μm\r\nSecond camera: 12 MP (Telephoto, OIS, PDAF)\r\nSpecifications: Optical zoom: 2x; Aperture size: F2.2; Focal Length: 65 mm\r\nThird camera: 12 MP (Ultra-wide)\r\nSpecifications: Aperture size: F2.4; Focal Length: 13 mm\r\nVideo recording: 3840x2160 (4K UHD) (60 fps), 1920x1080 (Full HD) (240 fps), 1280x720 (HD) (30 fps)\r\nFeatures: OIS, HDR, Time-lapse video, Continuous autofocus, Picture-taking during video recording, Video light\r\nFront: 12 MP (Time-of-Flight (ToF), EIS, HDR, Slow-motion videos)\r\nVideo capture: 3840x2160 (4K UHD) (60 fps)\r\nDESIGN\r\nDimensions: 6.33 x 3.07 x 0.29 inches (160.84 x 78.09 x 7.39 mm)\r\nWeight: 8.03 oz (228.0 g)\r\nMaterials: Back: Glass; Frame: Stainless steel\r\nMaterials & Colors: Pacific Blue\r\nResistance: Water, Splash, Dust; IP68\r\nBiometrics: 3D Face unlock\r\nKeys: Left: Volume control, Other; Right: Lock/Unlock key\r\nCELLULAR\r\n5G: n1, n2, n3, n5, n7, n8, n12, n20, n25, n28, n38, n40, n41, n66, n71, n77, n78, n79, n260, n261, Sub-6, mmWave\r\nLTE (FDD): Bands 1(2100), 2(1900), 3(1800), 4(AWS-1), 5(850), 7(2600), 8(900), 12(700 a), 13(700 c), 14(700 PS), 17(700 b), 18(800 Lower), 19(800 Upper), 20(800 DD), 25(1900+), 26(850+), 28(700 APT), 29(700 d), 30(2300 WCS), 32(1500 L-band), 66(AWS-3), 71(600)\r\nLTE (TDD): Bands 34(2000), 38(2600), 39(1900+), 40(2300), 41(2600+), 42(3500), 46, 48(3600)\r\nUMTS: 850, 900, 1700/2100, 1900, 2100 MHz\r\nData Speed: LTE-A, HSDPA+ (4G) 42.2 Mbit/s, HSUPA 5.76 Mbit/s, UMTS\r\nDual SIM: Yes\r\nSIM type: Nano SIM, eSIM\r\nHD Voice: Yes\r\nVoLTE: Yes\r\nMULTIMEDIA\r\nHeadphones: No 3.5mm jack\r\nSpeakers: Earpiece, Loudspeaker\r\nFeatures: Dolby Atmos\r\nScreen mirroring: Wireless screen share\r\nAdditional microphone(s): for Noise cancellation\r\nCONNECTIVITY & FEATURES\r\nBluetooth: 5.0\r\nWi-Fi: 802.11 a, b, g, n, ac, ax (Wi-Fi 6), dual-band; MIMO, Wi-Fi Direct, Hotspot\r\nUSB: Lightning\r\nFeatures: Charging, Headphones port\r\nLocation: GPS, A-GPS, Glonass, Galileo, BeiDou, QZSS, Cell ID, Wi-Fi positioning\r\nSensors: Accelerometer, Gyroscope, Compass, Barometer, LiDAR scanner\r\nOther: NFC, UMA (Wi-Fi Calling)\r\nHearing aid compatible: M3, T4\r\nBrand : Apple\r\nColor : Pacific Blue\r\nOperating System Type : iOS\r\nStorage Capacity : 128GB\r\nNumber Of SIM : Single SIM & E-SIM\r\nRear Camera Resolution : 12 megapixels\r\nMobile Phone Type : Mobile Phone\r\nCellular Network Technology : 5G\r\nChipset manufacturer : Apple\r\nDisplay Size (Inch) : 6.7 inches\r\nModel Number : iPhone 12 Pro Max\r\nBattery Capacity in mAh : 3,687mAh\r\nFast Charge : Yes\r\nMemory RAM : 6 GB",
                            Image="https://student.valuxapps.com/storage/uploads/products/1615440322npwmU.71DVgBTdyLL._SL1500_.jpg"
                        },
                         new Product()
                        {
                            Name = "JBL Xtreme 2 Portable Waterproof Bluetooth Speaker - Blue JBLXTREME2BLUAM",
                            Old_Price=10230,
                            Price=5599,
                            Discount=45,
                            Quentity=31,
                            CategoryId=1,
                            Description="GENERAL SPECIFICATIONS\r\nMusic playing time: 15 hours\r\nOutput power (W): 2 x 20\r\nDIMENSIONS\r\nDimensions: 13.6 x 28.8 x 13.2 centimeters\r\nWeight: 2.39 kilograms\r\nCONTROL AND CONNECTION SPECIFICATIONS\r\nBluetooth version: 4.2\r\nBATTERY\r\nBattery capacity: 10000 mAh\r\nCharging time: 3.5 hours\r\nFEATURES\r\n3.5 mm audio cable Input: Yes\r\nAuto power off: Yes\r\nBluetooth: Yes\r\nJBL Connect+: Yes\r\nPower bank: Yes\r\nSpeakerphone: Yes\r\nVoice Assistant: Yes\r\nWaterproof: Yes",
                            Image="https://student.valuxapps.com/storage/uploads/products/1615440689wYMHV.item_XXL_36330138_142814934.jpeg"
                        },
                          new Product()
                        {
                            Name = "Samsung 65 Inch Smart TV 4K Ultra HD Curved - UA65RU7300RXUM",
                            Old_Price=12499,
                            Price=11499,
                            Discount=12,
                            Quentity=4,
                            CategoryId=1,
                            Description="Brand: Samsung\r\nColor: black\r\nModel: UA65RU7300\r\nType: Curve\r\nSize: 65 inch\r\nHDMI: 3\r\nUSB: 2\r\nSmart: Yes\r\nOne Remote: Yes\r\nResolution: 3,840 x 2,160\r\nWeight: 25.0 kg\r\nDimensions (WxHxD): 145.27 x 83.81 x 12.09 cm\r\nAI Upscale: N/A\r\nSmart View: Yes",
                            Image="https://student.valuxapps.com/storage/uploads/products/1615441020ydvqD.item_XXL_51889566_32a329591e022.jpeg"
                        },
                           new Product()
                        {
                            Name = "Apple MacBook Pro",
                            Old_Price=44500,
                            Price=44500,
                            Discount=0,
                            Quentity=3,
                            CategoryId=1,
                            Description="Bring home the Apple MacBook Pro and experience computing like never before. This Apple laptop features a powerful 2.3Ghz 8th Gen-Intel Core i5 processor that makes sure the system keeps performing efficiently. Experience smooth and fast multitasking with the 8GB RAM. The Intel Iris Plus Graphics render images in high-quality and make your gaming experience a pleasing one. The macOS operating system offers various user-friendly features. Store your movies, audios, and other important files comfortably on the 512GB SSD of this device. The 13.3inch display allows you to view your favorite movies and other content in high quality. The Retina display features bright LED backlighting and a high contrast ratio that enhances your viewing experience. The True Tone technology provides a natural viewing experience by adjusting the white balance of the screen as per the color temperature of the light around. Featuring well-balanced, high-fidelity sounds, this laptop delivers an immersive audio experience. The Apple T2 chip lets you store your data in an encrypted format with the help of its Secure Enclave coprocessor. Also, it tightens the security further with the help of the Touch ID. The Touch ID only allows you to unlock your laptop using your fingerprints. The Touch Bar controls simplify various activities such as sending an email or formatting a document. This lightweight laptop can be easily carried around in your backpack. It features a space grey that gives it a distinguished and beautiful look.",
                            Image="https://student.valuxapps.com/storage/uploads/products/1615442168bVx52.item_XXL_36581132_143760083.jpeg"
                        },
                            new Product()
                        {
                            Name = "Nikon FX-format D750 - 24.3 MP, SLR Camera 24-120mm Lens, Black",
                            Old_Price=35000,
                            Price=32860,
                            Discount=6,
                            Quentity=3,
                            CategoryId=1,
                            Description="The Nikon FX Format D750 SLR Camera comes loaded with an array of advanced features that provide total control, enabling you to capture life’s fleeting moments in their purest form. The compact camera comes with 24 to 120mm NIKKOR lens that is perfect for capturing portraits, landscapes, and weddings. Even though this imaging device is small and lightweight, it does not compromise on performance. The device’s impressive 24.3MP CMOS image sensor and EXPEED 4 engine provide you with the ability to shoot stellar photos and videos, even in low light conditions. The sleek black camera’s movie shooting menu with preset control settings make it possible to record 1080/60p Full HD movies with reduced moiré and minimal jaggies. The SLR camera’s 3.2inch tilting TFT LCD monitor has a resolution of approximately 1229K dots. It makes it convenient for you to compose shots from tricky angles or playback the captured footage. The device’s built in WiFi simplifies on the spot sharing of your images and videos with the world. The inclusion of all these and several other sought after features make the Nikon D750 perfect for pro and semi pro photographers alike.",
                            Image="https://student.valuxapps.com/storage/uploads/products/1615450256e0bZk.item_XXL_7582156_7501823.jpeg"
                        },
                             new Product()
                        {
                            Name = "Kingston A400 Internal SSD 2.5\" 240GB SATA 3 - SA400S37/240G",
                            Old_Price=530,
                            Price=530,
                            Discount=0,
                            Quentity=3,
                            CategoryId=1,
                            Description="Brand : kingston\r\nStorage Capacity : 240 GB\r\nCompatible operating systems : Windows\r\nInterface Type : SATA\r\nDrive Type : SSD\r\nStorage Device Use : Internal Laptop\r\nModel Number : SA400S37/240G",
                            Image="https://student.valuxapps.com/storage/uploads/products/1615451352LMOAF.item_XXL_23705724_34135503.jpeg"
                        },
                              new Product()
                        {
                            Name = "Xiaomi Redmi 10 Dual SIM Mobile- 6.53 Inch FHD , 64GB, 4GB RAM, 4G LTE - Carbon Gray",
                            Old_Price=3075.260000,
                            Price=3075.2600000,
                            Discount=0,
                            Quentity=3,
                            CategoryId=1,
                            Description="Model name\tXiaomi Redmi 10\r\nWireless carrier\tUnlocked for All Carriers\r\nBrand\tXiaomi\r\nForm factor\tFoldable Screen\r\nMemory storage capacity\t4 GB\r\nOS\tAndroid 11.0\r\nColour\tCarbon Gray\r\nCellular technology\tLTE\r\nSIM card slot count\tDual SIM\r\nModel year\t2021\r\n------------\r\nAbout this item\r\nAI quad camera | 90Hz FHD+ display , 5000mAh battery , Gaming CPU , fast charging\r\nWeight: 181g\r\nHelio G88 processor,Octa-Core ,12nm manufacturing process Dimensions:161.95mm x 75.53mm x 8.92mm\r\nMain camera : 50MP\r\nFront camera : 8MP",
                            Image="https://student.valuxapps.com/storage/uploads/products/1638734961565J3.11.jpg"
                        },
                               new Product()
                        {
                            Name = "Xiaomi Mi Smart Band 5 - Black",
                            Old_Price=656,
                            Price=444,
                            Discount=32,
                            Quentity=3,
                            CategoryId=1,
                            Description="Brand\tXiaomi\r\nWireless communication standard\tBluetooth\r\nColour\tBlack\r\nCompatible devices\tMulti\r\nHuman interface input\tTouchscreen\r\nScreen size\t3 Inches\r\nBandwidth\t15 Millimeters\r\nWireless carrier\t3\r\n---------------\r\nAbout this item\r\nLightweight design\r\nMade of high quality materials\r\nWater resistant",
                            Image="https://student.valuxapps.com/storage/uploads/products/1638735246ToPmP.21.jpg"
                        },
                                new Product()
                        {
                            Name = "Sony Pulse 3D Wireless Gaming Headset for PlayStation 5",
                            Old_Price=2659.05,
                            Price=1596.920,
                            Discount=40,
                            Quentity=3,
                            CategoryId=1,
                            Description="Brand\tSony\r\nColour\tWhite & Black\r\nConnectivity technology\tWireless\r\nItem weight\t1.5 Pounds\r\nCompatible Devices\tMulti\r\n---------------------\r\nAbout this item\r\nBuilt for a new generation\r\nFine-tuned for 3D Audio on PS5 consoles1.\r\nEnjoy comfortable gaming with refined earpads and headband strap.\r\nPlay in style with a sleek design that complements the PS5 console.\r\nDesigned for gamers; Chat with friends through the hidden noise-cancelling microphones2.\r\nQuickly adjust audio and chat settings with easy-access controls",
                            Image="https://student.valuxapps.com/storage/uploads/products/16387377980g2kx.11.jpg"
                        },
                                 new Product()
                        {
                            Name = "Sony WI-C200 Wireless Headphones - Black",
                            Old_Price=999,
                            Price=499,
                            Discount=0,
                            Quentity=7,
                            CategoryId=1,
                            Description="Brand\tSony\r\nColour\tBlack\r\nConnectivity technology\tWireless\r\nItem weight\t0.01 Kilograms\r\nCompatible devices\tAll\r\nWireless communication technologies\tBluetooth\r\nStyle\tClosed-back\r\n-----------------\r\nAbout this item\r\nCompatible with multiple devices and easy to use.\r\nBalanced Pure Sound\r\nDesigned and tested for using safely",
                            Image="https://student.valuxapps.com/storage/uploads/products/1638737964KFEyZ.21.jpg"
                        },
                                 /// sport
                                 new Product()
                        {
                            Name = "Stark Iron Kettlebell, 24 KG",
                            Old_Price=1083,
                            Price=1083,
                            Discount=0,
                            Quentity=4,
                            CategoryId=3,
                            Description="Brand: Stark\r\nColor: Black\r\nWeight: 24 Kg\r\nTargeted Group: Unisex",
                            Image="https://student.valuxapps.com/storage/uploads/products/161545152160GOl.item_XXL_39275650_152762070.jpeg"
                        },
                                  new Product()
                        {
                            Name = "Nike Men's NSW Tee Icon Futura, Black(Black/White010), Medium",
                            Old_Price=1085,
                            Price=1085,
                            Discount=0,
                            Quentity=4,
                            CategoryId=3,
                            Description="Nike sportswear men's T-Shirt classic cotton comfort\r\nThe nike sportswear t-Shirt sets you up with soft cotton jersey and a classic logo on the chest\r\nCotton jersey fabric is soft and comfortable",
                            Image="https://student.valuxapps.com/storage/uploads/products/1638737571de5EF.21.jpg"
                        },
                                   new Product()
                        {
                            Name = "Nike Flex Essential Mesh Training Shoes For Women - White",
                            Old_Price=1606.5,
                            Price=1606.5,
                            Discount=0,
                            Quentity=4,
                            CategoryId=3,
                            Description="Women's Nike Flex Essential Training Shoes pairs a lightweight, breathable upper with a supportive platform designed for flexibility and traction in every direction. Ideal for light workouts and all-day wear, this shoe is flexible to whatever you have planned.\r\n\r\nMesh synthetic construction provides breathable containment\r\nLightweight foam midsole for comfortable cushioning\r\nSections of durable rubber tread for excellent traction\r\nDeep flex grooves allow your foot to move naturally\r\nStyle: 924344-100",
                            Image="https://student.valuxapps.com/storage/uploads/products/1638737146iLO2c.11.jpg"
                        },
                                   //clothes
                                   new Product()
                        {
                            Name = "Winter High Collar Pullover - Camel",
                            Old_Price=160,
                            Price=110,
                            Discount=30,
                            Quentity=5,
                            CategoryId=5,
                            Description="We strive to provide products that combine fashion and practical life, as our products are manufactured from the best materials and innovative technologies in the field of fabrics, colors and designs",
                            Image="https://student.valuxapps.com/storage/uploads/products/1644372386y0SzM.4.jpg"
                        },
                                    new Product()
                        {
                            Name = "Fashion Solid Color Collage Collar Men Jacket",
                            Old_Price=692,
                            Price=404,
                            Discount=40,
                            Quentity=5,
                            CategoryId=5,
                            Description="Product Category: Jackets\r\n- Style: Casual sports\r\n- Length: long-sleeved\r\n- Lining Material: Polyester (PET)\r\n- Thickness: Thin section\r\n- type version: fit body\r\n- Size: M, L, XL, XXL, XXXL, XXXXL, 5XL\r\n- Colors: brown blue, gray blue\r\n- Length: general section (50cm - 65cm)",
                            Image="https://student.valuxapps.com/storage/uploads/products/1644374518pTaSB.10.jpg"
                        },
                                     new Product()
                        {
                            Name = "Front Patch Pocket Long Sleeve Shirt - Dark Olivel",
                            Old_Price=475,
                            Price=225,
                            Discount=53,
                            Quentity=7,
                            CategoryId=5,
                            Description="Our model wears a size L\r\ncotton material\r\nRegular fit\r\nlong sleeves",
                            Image="https://student.valuxapps.com/storage/uploads/products/1644375298PFm8i.14.jpg"
                        },

                    }); ;
                    context.SaveChanges();
                }


            }

        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRole.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRole.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRole.User));


        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        string adminUserEmail = "admin@yahoo.com";
        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new ApplicationUser()
        //            {
        //                FullName = "Admin User",
        //                UserName = "admin-user",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Aa@1234");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
        //        }


        //        string appUserEmail = "user@yahoo.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new ApplicationUser()
        //            {
        //                FullName = "Application User",
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAppUser, "Aa@1234");
        //            await userManager.AddToRoleAsync(newAppUser, UserRole.User);
        //        }



        //    }
        //}


    }
}
