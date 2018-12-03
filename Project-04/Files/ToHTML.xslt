<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:b="http://my.company.com">
  <xsl:output method="html"/>

    <xsl:template match="/">
      
        <xsl:apply-templates select="//b:commercial"/>
    
    </xsl:template>
    <xsl:template match="b:commercial">
      <div class="commercial">
      <a>
        <xsl:attribute name="href">
          http://<xsl:value-of select="b:webpage"/>
        </xsl:attribute>
        <h4><xsl:value-of select="@company"/></h4>
        <img class="com-img" alt="banner">
            <xsl:attribute name="src">
              ../img/<xsl:value-of select="b:logo"/>
              <xsl:value-of select="b:ourlogo"/>
            </xsl:attribute>      
        </img>
      </a>
      </div>
    </xsl:template>
</xsl:stylesheet>
