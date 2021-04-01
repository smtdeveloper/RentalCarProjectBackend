GitHub License GitHub Repo stars GitHub repo size

<br>
<h2> <a href="https://github.com/smtdeveloper/SametAkca">Read Me :) Daha Fazla</a>
 </h2>
<br>

<h4> 
 Bu proje SOLID prensiplerine uygun bir şekilde, eğitim tekrarı niteliğinde hazırlanmıştır.
Proje Aspect'ler (Validation[FluentValidation], Transaction, Cache, Performance) barındırmaktadır.
JWT entegre edilmiştir ve Autofac desteği kullanılmıştır. 
</h4>

ReCap Project : Araba Kiralama Sistemi
Rent A Car

⭐ Introduction
Entities, DataAccess, Business, Core ve WebAPI katmanlarından oluşan araba kiralama projesidir. Bu projede Katmanlı mimari yapısı ve SOLID prensiplerine dikkate alınarak yazılmıştır. JWT entegrasyonu; Transaction, Cache, Validation ve Performance aspect'lerinin implementasyonu gerçekleştirilmiştir.
Validation için FluentValidation desteği, IoC için ise Autofac desteği eklenmiştir.
Sql query dosyamı da ekledim isteyen varsa faydalanabilir.
Recent Changes
✔ Caching, Transaction ve Performance aspectleri eklendi.
✔ CarManager class'ına ait olan GetAll metoduna Logging aspect'i eklendi.
✔ Car nesnesinin GetAll metodu performance ile test edildi.
✔ Çalıştırılan metodlar log4net.config ile log.json dosyasına yazıldı.

Table of Contents
Recent Changes
Installation
Usage
Layers
SQL Query
Tables in Database
Output
Files
License
Installation 
# Clone to repository
$ git clone https://github.com/smtdeveloper/ReCarProject
# Go to the folder you cloned
$ cd re-cap-project-with-csharp

# Install dependencies
$ dotnet restore
Usage
Aşağıda görmüş olduğunuz resimdeki işlemi gerçekleştirdikten sonra Ctrl+F5 ile uygulamayı çalıştırabilirsiniz. Daha sonrasında Postman uygulaması aracılığıyla projeye isteklerde bulunabilirsiniz.

Image for Usage

Layers
🗃 Entities Layer
    📂 Concrete
         📃 Brand.cs
         📃 Car.cs
         📃 CarImage.cs
         📃 Color.cs
         📃 Customer.cs
         📃 Rental.cs

    📂 DTOs
         📃 CarDetailDto.cs
         📃 RentalDetailDto.cs

         📃 UserForLoginDto.cs

         📃 UserForRegisterDto.cs


🗃 Business Layer
     📂 Abstract
         📃 IAuthService.cs
         📃 IBrandService.cs
         📃 ICarImageService.cs
         📃 ICarService.cs
         📃 IColorService.cs
         📃 ICustomerService.cs
         📃 IRentalService.cs
         📃 IUserService.cs

    📂 BusinessAspect
        📂 Autofac
             📃 SecuredOperation.cs

    📂 Concrete
         📃 AuthManager.cs
         📃 BrandManager.cs
         📃 CarImageManager.cs
         📃 CarManager.cs
         📃 ColorManager.cs
         📃 CustomerManager.cs
         📃 RentalManager.cs
         📃 UserManager.cs

     📂 Constants
         📃 Messages.cs

     📂 DependencyResolvers
         📂 Autofac
             📃 AutofacBusinessModule.cs

     📂 ValidationRules
         📂 FluentValidation
             📃 BrandValidator.cs
             📃 CarValidator.cs
             📃 ColorValidator.cs
             📃 CustomerValidator.cs
             📃 RentalValidator.cs
             📃 UserValidator.cs


🗃 Data Access Layer
    📂 Abstract
         📃 IBrandDal.cs
         📃 ICarImageDal.cs
         📃 ICarDal.cs
         📃 IColorDal.cs
         📃 ICustomerDal.cs
         📃 IRentalDal.cs
         📃 IUserDal.cs

     📂 Concrete
         📂 EntityFramework
             📂 Context
                 📃 RentACarContext.cs
             📂 Repository
                 📃 EfBrandDal.cs
                 📃 EfCarImageDal.cs
                 📃 EfCarDal.cs
                 📃 EfColorDal.cs
                 📃 EfCustomerDal.cs
                 📃 EfRentalDal.cs
                 📃 EfUserDal.cs


🗃 Core Layer
    📂 Aspect
        📂 Autofac
            📂 Caching
                 📃 CacheAspect.cs
                 📃 CacheRemoveAspect.cs
            📂 Expection
                 📃 ExceptionLogAspect.cs
            📂 Logging
                 📃 LogAspect.cs
            📂 Performance
                 📃 PerformanceAspect.cs
            📂 Transaction
                 📃 TransactionScopeAscpect.cs
            📂 Validation
                 📃 ValidationAspect.cs

    📂 CrossCuttingConcerns
        📂 Caching
            📃 ICacheManager.cs
            📂 Microsoft
                📃 MemoryCacheManager.cs
        📂 Logging
            📃 LogDetail.cs
            📃 LogDetailWithException.cs
            📃 LogParameter.cs
            📂 Log4Net
                📃 LoggerServiceBase.cs
                📃 SerializableLogEvent.cs
                📂 Layouts
                    📃 JsonLayout.cs
                📂 Loggers
                    📃 FileLogger.cs
        📂 Validation
            📃 ValidationTool.cs

    📂 DataAccess
         📃 IEntityRepository.cs
        📂 EntityFramework
             📃 EfEntityRepositoryBase.cs

    📂 DependencyResolvers
         📃 CoreModule.cs

    📂 Entities
         📃 IDto.cs
         📃 IEntity.cs
        📂 Concrete
             📃 OperationClaim.cs
             📃 User.cs
             📃 UserOperationClaim.cs

    📂 Extensions
         📃 ClaimExtensions.cs
         📃 ClaimsPrincipalExtensions.cs
         📃 ServiceCollectionExtensions.cs

    📂 Utilities
        📂 Business
             📃 BusinessRules.cs
        📂 Helpers
             📃 FileHelper.cs
        📂 Interceptors
             📃 AspectInterceptorSelector.cs
             📃 MethodInterception.cs
             📃 MethodInterceptionBaseAttribute.cs
        📂 IoC
             📃 ICoreModule.cs
             📃 ServiceTool.cs
        📂 Messages
             📃 AspectMessages.cs
        📂 Results
             📃 IDataResult.cs
             📃 DataResult.cs
             📃 SuccessDataResult.cs
             📃 ErrorDataResult.cs
             📃 IResult.cs
             📃 Result.cs
             📃 SuccessResult.cs
             📃 ErrorResult.cs
        📂 Security
            📂 Encryption
                 📃 SecurityKeyHelper.cs
                 📃 SigningCredentialsHelper.cs
            📂 Hashing
                 📃 HashingHelper.cs
            📂 JWT
                 📃 AccessToken.cs
                 📃 ITokenHelper.cs
                 📃 JwtHelper.cs
                 📃 TokenOptions.cs


🗃 Presentation Layer
     📃 Program.cs


🗃 WebAPI Layer
    📃 Startup.cs
    📂 Controllers
         📃 AuthController.cs
         📃 BrandsController.cs
         📃 CarImagesController.cs
         📃 CarsController.cs
         📃 ColorsController.cs
         📃 CustomersController.cs
         📃 RentalsController.cs
         📃 UsersController.cs


SQL Query
     📃 RentACarSQLQuery.sql

Tables in Database

Brands	CarImages	Cars	Colors	Customers	OperationClaims	Rentals	UserOperationClaims	Users
Variable Name	Data Type
Id	INT
BrandName	NVARCHAR(25)	
Variable Name	Data Type
Id	INT
CarId	INT
CarImagesDate	DATETIME
ImagePath	NVARCHAR(MAX)	
Variable Name	Data Type
Id	INT
BrandId	INT
ColorId	INT
ModelYear	NVARCHAR(25)
DailyPrice	DECIMAL
Description	NVARCHAR(25)	
Variable Name	Data Type
Id	INT
ColorName	NVARCHAR(25)	
Variable Name	Data Type
Id	INT
UserId	INT
CustomerName	NVARCHAR(25)	
Variable Name	Data Type
Id	INT
Name	VARCHAR(250)	
Variable Name	Data Type
Id	INT
CarId	INT
CustomerId	INT
RentDate	DATETIME
ReturnDate	DATETIME	
Variable Name	Data Type
Id	INT
UserId	INT
OperationId	INT	
Variable Name	Data Type
Id	INT
FirstName	VARCHAR(50)
LastName	VARCHAR(50)
Email	VARCHAR(50)
PasswordHash	VARBINARY (500)
PasswordSalt	VARBINARY (500)
Status	BIT
Output
Console Output



<br>
<h1> Sosyal Medya Hesaplarım </h1>
<br>
<a href="https://www.instagram.com/smtcoder/"> instagram  :  @SMTcoder :)  </a>
<br> 
<a href="https://www.linkedin.com/in/samet-akca-2a4bbb1a8/"> linkedin    : @SametAkca :)  </a>
<br>
<br> 
<br>



<a href="https://github.com/smtdeveloper/SametAkca"> Read Me :) Daha Fazla </a>

SMTdeveloper
<br>
2021 © <a href="https://github.com/smtdeveloper"> Samet Akca </a>

