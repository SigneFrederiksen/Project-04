<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:b="http://my.company.com">
  <xsl:output method="html"/>

    <xsl:template match="/">
      <div id="commercial">
        <xsl:apply-templates select="//b:commercial"/>
      </div>
    </xsl:template>
    <xsl:template match="b:commercial">
        <h4><xsl:value-of select="@company"/></h4>
        <p><xsl:value-of select="b:logo"/></p>
        <p><xsl:value-of select="b:ourlogo"/></p>
    </xsl:template>
</xsl:stylesheet>
