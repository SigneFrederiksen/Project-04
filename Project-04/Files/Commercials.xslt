<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:b="http://my.company.com">
    <xsl:output method="xml" indent="yes"/>
      <xsl:template match="b:commercials">
        <xsl:element name="Commercials">
          <xsl:apply-templates select="b:commercial"/>
        </xsl:element>
      </xsl:template>
      <xsl:template match="b:commercial">
        <xsl:element name="Commercial">
            <xsl:element name="Company">
              <xsl:value-of select="@company"/>
              <xsl:text></xsl:text>
            </xsl:element>
          <xsl:element name="Logo">
            <xsl:value-of select="b:logo"/>
            <xsl:value-of select="b:ourlogo"/>
            <xsl:text></xsl:text>
          </xsl:element>
          <xsl:element name="Webpage">
            <xsl:value-of select="b:webpage"/>
            <xsl:text></xsl:text>
          </xsl:element>
        </xsl:element>
      </xsl:template>     
</xsl:stylesheet>
