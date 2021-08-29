# docker build -t kpmg-assessment-api .
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

LABEL name="kpmg.assessment.api" \
    contact="jaskhundal@gmail.com" \
    description="API provides backend capabilites to Dog CEO"

# copy csproj and restore as distinct layers
COPY . .

# publish release
RUN dotnet publish ./kpmg.assessment.api/kpmg.assessment.api.csproj -c Release -o ./out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 5000

ENTRYPOINT [ "dotnet", "kpmg.assessment.api.dll" ]



# docker run -p 5000:5000 -it kpmg-assessment-api