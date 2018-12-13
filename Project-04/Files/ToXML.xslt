<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
                xmlns:c="http://my.company.com">
<xsl:output method="xml" indent="yes"/>
  <xsl:template match="c:commercials">
    <xsl:element name="Commercials">
      <xsl:apply-templates select="c:commercial"/>
    </xsl:element>
  </xsl:template>
  <xsl:template match="c:commercial">
    <xsl:element name="Commercial">
      <xsl:element name="Company">
        <xsl:value-of select="@company"/>
      </xsl:element>
      <xsl:element name="Logo">
        <xsl:value-of select="c:logo"/>
        <xsl:value-of select="c:ourlogo"/>
      </xsl:element>
      <xsl:element name="Webpage">
        <xsl:value-of select="c:webpage"/>
      </xsl:element>
      <xsl:element name="Viewcount">
        <xsl:value-of select="0"/>
      </xsl:element>
    </xsl:element>
  </xsl:template> 
</xsl:stylesheet>

