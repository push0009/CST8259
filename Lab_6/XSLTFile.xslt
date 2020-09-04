<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>
  <xsl:param name="minRating">0</xsl:param>
  <xsl:template match="/">
    <div>
      <xsl:choose>
        <xsl:when test="count(restaurants/restaurant[Rating &gt; $minRating]) &gt; 0">
          <xsl:apply-templates select="restaurants/restaurant[Rating &gt; $minRating]">
            <xsl:sort select="Rating" order="descending"/>
          </xsl:apply-templates>
        </xsl:when>
        <xsl:otherwise>
          <p>
            No restaurant having rating above <xsl:value-of select="$minRating"/>.
          </p>
        </xsl:otherwise>
      </xsl:choose>
    </div>
  </xsl:template>

  <xsl:template match="restaurant">
    <h2>
      <xsl:value-of select="name" />
    </h2>
    <div style="margin-left: 20px">
      <ul>
        <li>
          Address:
          <xsl:value-of select="Address/street" />,
          <xsl:value-of select="Address/city" />,
          <xsl:value-of select="Address/province" />,
          <xsl:value-of select="Address/postalCode" />
        </li>
        <li>
          Phone:
          (<xsl:value-of select="Phone/areaCode" />) <xsl:value-of select="Phone/number" />
        </li>
      </ul>
      <h4>Summary</h4>
      <div style="margin-left: 20px">
        <xsl:value-of select="Summary" />
      </div>
      <h4 style="">
        Rating: <span style="margin-left: 5px">
          <xsl:value-of select="Rating" />
        </span>
      </h4>
      <h4>Menu</h4>
      <div style="margin-left: 20px">
        <table border="2" style="width: 80%">
          <tr>
            <th>Description</th>
            <th>Quentity</th>
            <th>Price</th>
          </tr>
          <tr>
            <th colspan="3" style="text-align: center">Appetizers</th>
          </tr>
          <xsl:for-each select="menu/Appetizers/Appetizer">
            <xsl:sort select="price" data-type="number"/>
            <tr>
              <td>
                <xsl:value-of select="description"/>
              </td>
              <td>
                <xsl:choose>
                  <xsl:when test="price/@quantity">
                    <xsl:value-of select="price/@quantity"/>
                  </xsl:when>
                  <xsl:otherwise>
                    1
                  </xsl:otherwise>
                </xsl:choose>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
            </tr>
          </xsl:for-each>
          <tr>
            <th colspan="3" style="text-align: center">Entrees</th>
          </tr>
          <xsl:for-each select="menu/Entrees/Entree">
            <xsl:sort select="price" data-type="number"/>
            <tr>
              <td>
                <xsl:value-of select="description"/>
              </td>
              <td>
                <xsl:choose>
                  <xsl:when test="price/@quantity">
                    <xsl:value-of select="price/@quantity"/>
                  </xsl:when>
                  <xsl:otherwise>
                    1
                  </xsl:otherwise>
                </xsl:choose>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </div>
    </div>
  </xsl:template>
</xsl:stylesheet>