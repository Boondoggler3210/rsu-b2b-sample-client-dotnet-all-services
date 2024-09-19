using System;
using System.Xml;

namespace UFSTWSSecuritySample
{
    public class ModtagMomsangivelseForeloebigWriter : IPayloadWriter
    {
        public string AngivelsePeriodeFraDato { get; private set; }
        public string AngivelsePeriodeTilDato { get; private set; }
        public string SENummer { get; private set; }
        public Angivelsesafgifter ReturnValues { get; private set; }


        public ModtagMomsangivelseForeloebigWriter(string seNummer, string angivelsePeriodeFraDato, string angivelsePeriodeTilDato, Angivelsesafgifter values)
        {
            SENummer = seNummer;
            AngivelsePeriodeFraDato = angivelsePeriodeFraDato;
            AngivelsePeriodeTilDato = angivelsePeriodeTilDato;
            ReturnValues = values;
        }

        public void Write(XmlTextWriter writer)
        {
            var now = DateTime.UtcNow.ToString("o").Substring(0, 23) + "Z";
            var transactionId = Guid.NewGuid().ToString();

            writer.WriteStartElement("urn", "ModtagMomsangivelseForeloebig_I", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
            writer.WriteAttributeString("xmlns", "ns", null, "http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/");
            writer.WriteAttributeString("xmlns", "ns1", null, "http://rep.oio.dk/skat.dk/motor/class/virksomhed/xml/schemas/20080401/");
            writer.WriteAttributeString("xmlns", "urn1", null, "urn:oio:skat:nemvirksomhed:1.0.0");
            writer.WriteStartElement("ns", "HovedOplysninger", null);
            writer.WriteStartElement("ns", "TransaktionIdentifikator", null);
            writer.WriteString(transactionId);
            writer.WriteEndElement(); // TransaktionIdentifikator
            writer.WriteStartElement("ns", "TransaktionTid", null);
            writer.WriteString(now);
            writer.WriteEndElement(); // TransaktionTid
            writer.WriteEndElement(); // HovedOplysninger
            writer.WriteStartElement("urn", "Angivelse", null);
            writer.WriteStartElement("urn", "AngiverVirksomhedSENummer", null);
            writer.WriteStartElement("ns1", "VirksomhedSENummerIdentifikator", null);
            writer.WriteString(SENummer);
            writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
            writer.WriteEndElement(); // AngiverVirksomhedSENummer
            writer.WriteStartElement("urn", "Angivelsesoplysninger", null);
            writer.WriteStartElement("urn1", "AngivelsePeriodeFraDato", null);
            writer.WriteString(AngivelsePeriodeFraDato);
            writer.WriteEndElement(); // AngivelsePeriodeFraDato
            writer.WriteStartElement("urn1", "AngivelsePeriodeTilDato", null);
            writer.WriteString(AngivelsePeriodeTilDato);
            writer.WriteEndElement(); // AngivelsePeriodeTilDato
            writer.WriteEndElement(); // Angivelsesoplysninger
            writer.WriteStartElement("urn", "Angivelsesafgifter", null);

            writer.WriteStartElement("urn1", "MomsAngivelseAfgiftTilsvarBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseAfgiftTilsvarBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseAfgiftTilsvarBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseCO2AfgiftBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseCO2AfgiftBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseCO2AfgiftBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseEUKoebBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseEUKoebBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseEUKoebBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseEUSalgBeloebVarerBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseEUSalgBeloebVarerBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseEUSalgBeloebVarerBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseIkkeEUSalgBeloebVarerBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseIkkeEUSalgBeloebVarerBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseIkkeEUSalgBeloebVarerBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseElAfgiftBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseElAfgiftBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseElAfgiftBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseEksportOmsaetningBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseEksportOmsaetningBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseEksportOmsaetningBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseGasAfgiftBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseGasAfgiftBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseGasAfgiftBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseKoebsMomsBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseKoebsMomsBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseKoebsMomsBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseKulAfgiftBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseKulAfgiftBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseKulAfgiftBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseMomsEUKoebBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseMomsEUKoebBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseMomsEUKoebBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseMomsEUYdelserBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseMomsEUYdelserBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseMomsEUYdelserBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseOlieAfgiftBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseOlieAfgiftBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseOlieAfgiftBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseSalgsMomsBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseSalgsMomsBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseSalgsMomsBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseVandAfgiftBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseVandAfgiftBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseVandAfgiftBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseEUKoebYdelseBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseEUKoebYdelseBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseEUKoebYdelseBeloeb

            writer.WriteStartElement("urn1", "MomsAngivelseEUSalgYdelseBeloeb", null);
            writer.WriteString(ReturnValues.MomsAngivelseEUSalgYdelseBeloeb.ToString());
            writer.WriteEndElement(); // MomsAngivelseEUSalgYdelseBeloeb

            writer.WriteEndElement(); // Angivelsesafgifter
            writer.WriteEndElement(); // Angivelse
            writer.WriteEndElement(); // ModtagMomsangivelseForeloebig_I

        }


    }
    public class Angivelsesafgifter
    {
        //Total VAT
        public int MomsAngivelseAfgiftTilsvarBeloeb
        {
            get {return (MomsAngivelseSalgsMomsBeloeb + MomsAngivelseMomsEUKoebBeloeb + MomsAngivelseMomsEUYdelserBeloeb) - (MomsAngivelseKoebsMomsBeloeb + MomsAngivelseOlieAfgiftBeloeb + MomsAngivelseElAfgiftBeloeb + MomsAngivelseGasAfgiftBeloeb + MomsAngivelseKulAfgiftBeloeb + MomsAngivelseCO2AfgiftBeloeb + MomsAngivelseVandAfgiftBeloeb); }
        }
        //CO2 Tax
        public int MomsAngivelseCO2AfgiftBeloeb { get; set; }
        //EU Acquisitions
        public int MomsAngivelseEUKoebBeloeb { get; set; }
        //EU Sales without VAT 
        public int MomsAngivelseEUSalgBeloebVarerBeloeb { get; set; }

        //goods. Reported to "Non-EU sales without VAT"
        public int MomsAngivelseIkkeEUSalgBeloebVarerBeloeb { get; set; }
        //Electricity Tax
        public int MomsAngivelseElAfgiftBeloeb { get; set; }
        //Other Goods and services without Tax
        public int MomsAngivelseEksportOmsaetningBeloeb { get; set; }
        //Natural Gas and City Tax
        public int MomsAngivelseGasAfgiftBeloeb { get; set; }
        //Input VAT
        public int MomsAngivelseKoebsMomsBeloeb { get; set; }
        //Coal Tax
        public int MomsAngivelseKulAfgiftBeloeb { get; set; }
        //VAt on Goods purchased Abroad
        public int MomsAngivelseMomsEUKoebBeloeb { get; set; }
        //VAT on services purchased Abroad
        public int MomsAngivelseMomsEUYdelserBeloeb { get; set; }
        //Oil and bottled gas Tax
        public int MomsAngivelseOlieAfgiftBeloeb { get; set; }
        //Sales VAT (Output)
        public int MomsAngivelseSalgsMomsBeloeb { get; set; }
        //Water Tax
        public int MomsAngivelseVandAfgiftBeloeb { get; set; }
        //Purchases of Services in EU
        public int MomsAngivelseEUKoebYdelseBeloeb { get; set; }
        // Value of certain Service sales to other EU countries
        public int MomsAngivelseEUSalgYdelseBeloeb { get; set; }


    }
}
