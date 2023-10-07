dotnet ef dbcontext scaffold \
"Data Source=DESKTOP-9ALB66F\\SQLEXPRESS;Initial Catalog=Maintenance;user=sa;pwd=1234" \
Microsoft.EntityFrameworkCore.SqlServer \
-c MyApiContext \
-o EF \
--no-onconfiguring \
--no-pluralize \
-p MyApi.DA/MyApi.DA.csproj \
-s MyApi/MyApi.csproj \
-f