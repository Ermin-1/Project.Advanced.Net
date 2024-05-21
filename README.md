# Projekt: Avancerad .NET Applikation

## Arkitektur och Tekniska Metoder

### Översikt

Den här applikationen är byggd med .NET och följer en lagerbaserad arkitektur för att säkerställa separation av ansvar, vilket gör koden mer underhållbar och skalbar. Arkitekturen består huvudsakligen av följande lager:

- **Controllers**: Hanterar HTTP-förfrågningar och svar. Innehåller affärslogik och validering.
- **Services**: Implementerar affärslogik och kommunicerar med datalagret.
- **Data Access Layer (DAL)**: Interagerar med databasen för CRUD-operationer.
- **Models**: Definierar datamodellerna som används i applikationen.
- **DTOs (Data Transfer Objects)**: Används för att överföra data mellan lager och för att säkerställa att endast nödvändig information exponeras.

### Val av Tekniska Metoder

#### 1. Användning av DTOs

**Val**: Vi använder DTOs för att säkerställa att endast nödvändig information exponeras och överförs mellan lager, vilket förbättrar säkerheten och minskar risken för oavsiktlig dataexponering.

**Fördelar**:
- Minskar risken för överexponering av data.
- Gör koden mer läsbar och underhållbar genom att tydligt definiera vilka data som överförs.

**Nackdelar**:
- Kräver mer kod och mappning, vilket kan öka utvecklingstiden.

#### 2. Användning av Repository Pattern

**Val**: Repository Pattern används för att hantera dataåtkomst, vilket gör det möjligt att abstrahera datalagret från resten av applikationen.

**Fördelar**:
- Ger en enhetlig och testbar datalageraccess.
- Gör det enkelt att byta ut datakällan utan att ändra applikationslogiken.

### Resonemang kring Arkitekturval

Vid utformningen av denna applikation har jag valt en lagerbaserad arkitektur för att säkerställa en tydlig separation av ansvar. Detta gör koden mer modulär och underhållbar. Genom att använda DTOs kan vi minimera risken för att känslig data exponeras, samtidigt som vi förbättrar säkerheten och prestandan genom att endast överföra nödvändig information.

Repository Pattern hjälper till att skapa en enhetlig metod för dataåtkomst, vilket underlättar testning och gör det möjligt att enkelt byta ut datakällor utan att påverka resten av applikationen. Även om detta kan leda till viss överhead, anser jag att fördelarna med modularitet och testbarhet överväger nackdelarna.

---

### Exempel på Arkitektur och Kodsammansättning

#### DTO-klasser

##### AppointmentDto.cs
```csharp
namespace Project.Advanced.Net.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
    }
}
