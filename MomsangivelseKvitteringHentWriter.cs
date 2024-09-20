using System;
using System.Xml;

namespace UFSTWSSecuritySample
{
	public class MomsangivelseKvitteringHentWriter : IPayloadWriter
	{
		public string SENummer { get; private set; }
		public string TransaktionIdentifier { get; private set; }
        public string TransactionId { get; private set; }


        public MomsangivelseKvitteringHentWriter(string seNummer, string transaktionIdentifier, Guid transactionId)
		{
			SENummer = seNummer;
			TransaktionIdentifier = transaktionIdentifier;
			TransactionId = transactionId.ToString();
        }

		public void Write(XmlTextWriter writer)
		{
			var now = DateTime.UtcNow.ToString("o").Substring(0, 23) + "Z";
			//var transactionId = Guid.NewGuid().ToString();

			writer.WriteStartElement("urn", "MomsangivelseKvitteringHent_I", "urn:oio:skat:nemvirksomhed:ws:1.0.0");
			writer.WriteAttributeString("xmlns", "ns", null, "http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/");
			writer.WriteAttributeString("xmlns", "ns1", null, "http://rep.oio.dk/skat.dk/motor/class/virksomhed/xml/schemas/20080401/");
			writer.WriteAttributeString("xmlns", "urn1", null, "urn:oio:skat:nemvirksomhed:1.0.0");
			writer.WriteStartElement("ns", "HovedOplysninger", null);
			writer.WriteStartElement("ns", "TransaktionIdentifikator", null);
			writer.WriteString(TransactionId);
			writer.WriteEndElement(); // TransaktionIdentifikator
			writer.WriteStartElement("ns", "TransaktionTid", null);
			writer.WriteString(now);
			writer.WriteEndElement(); // TransaktionTid
			writer.WriteEndElement(); // HovedOplysninger
			writer.WriteStartElement("urn1", "TransaktionIdentifier", null);
			writer.WriteString(TransaktionIdentifier);
			writer.WriteEndElement(); // TransaktionIdentifier
			writer.WriteStartElement("urn", "Angiver", null);
			writer.WriteStartElement("ns1", "VirksomhedSENummerIdentifikator", null);
			writer.WriteString(SENummer);
			writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
			writer.WriteEndElement(); // Angiver
			writer.WriteEndElement(); // MomsangivelseKvitteringHent_I

		}
	}
}