<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:fo="http://www.w3.org/1999/XSL/Format">
  <xsl:template match="/">
    <fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">

      <!-- defines the layout master -->
      <fo:layout-master-set>
        <fo:simple-page-master master-name="USLetter"
                               page-height="8.5in"
                               page-width="11in"
                               margin-top=".5in"
                               margin-left=".75in"
                               margin-right=".75in"
                               margin-bottom="1in">
          <fo:region-body margin-top="1in"
                          margin-bottom=".6in"/>
          <fo:region-before extent="1in"/>
          <fo:region-after extent=".5in"/>
        </fo:simple-page-master>
      </fo:layout-master-set>

      <!-- starts actual layout -->
      <fo:page-sequence master-reference="USLetter">

        <fo:static-content flow-name="xsl-region-before">
          <fo:block font-size="9pt">
            <fo:table height=".99in"
                      width="9.5in"
                      table-layout="fixed"
                      border=".01in solid black">
              <fo:table-column column-width=".6in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".6in" />
              <fo:table-column column-width=".6in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-body>
                <fo:table-row height=".5in">
                  <fo:table-cell number-columns-spanned="9"
                                 border-bottom=".01in solid black"
                                 border-right=".01in solid black">
                    <fo:block  padding-top=".2in"
                               text-align="center"
                               font-size="15pt"
                               font-weight="bold">FLIGHT TIME SUMMARY</fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="5"
                                 border-bottom=".01in solid black">
                    <fo:block padding-top=".2in"
                              text-align="center"
                              font-size="12pt">
                      Page <fo:page-number/> of
                      <fo:page-number-citation ref-id="theEnd"/> Pages
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row height=".49in">
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Date</fo:block>
                    <fo:block space-before=".05in">
                      <xsl:value-of select="FlightTimeSummary/@Date"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">MDS</fo:block>
                    <fo:block space-before=".05in">
                      <xsl:value-of select="FlightTimeSummary/@MDS"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Serial No.</fo:block>
                    <fo:block space-before=".05in">
                      <xsl:value-of select="FlightTimeSummary/@SerialNumber"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="3"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Unit Charged For Flying Hours</fo:block>
                    <fo:block space-before=".05in">
                      <xsl:value-of select="FlightTimeSummary/@OperatingUnit"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="3"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Location</fo:block>
                    <fo:block space-before=".05in">
                      <xsl:value-of select="FlightTimeSummary/@Location"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="4">
                    <fo:block></fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
        </fo:static-content>

        <fo:static-content flow-name="xsl-region-after">
          <fo:block font-size="9pt"
                    font-weight="bold">
            <fo:block>
              TFS FORM 781 - Flight Time Summary - Previous Edition Obsolete
            </fo:block>
            <fo:block>
              Generated: <xsl:value-of select="FlightTimeSummary/@GeneratedDate"/>
            </fo:block>
          </fo:block>
        </fo:static-content>

        <fo:flow flow-name="xsl-region-body">



          <!-- this defines a title level 1-->
          <!--
          <fo:block font-size="18pt"
                    font-family="sans-serif"
                    line-height="24pt"
                    space-after.optimum="15pt"
                    background-color="blue"
                    color="white"
                    text-align="center"
                    padding-top="3pt"
                    border-width="5mm">
            My Book List
          </fo:block>-->


          <fo:block font-size="10pt"
                    text-align="center">
            <fo:table width="9.5in"
                      table-layout="fixed"
                      border-width=".01in"
                      border-style="solid"
                      border-color="black">
              <fo:table-column column-width=".6in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".6in" />
              <fo:table-column column-width=".6in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-column column-width=".7in" />
              <fo:table-body>
                <!-- Mission Header Row -->
                <fo:table-row>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Flt No.</fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="2"
                                 border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Mission No.</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">From (ICAO)</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">To (ICAO)</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Take Off Time (Z)</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Land Time (Z)</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Flight Time</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">
                      Touch
                      /Go
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Full Stop</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Total</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Sorties</fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="2"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Special Use</fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <!-- Mission Rows -->
                <xsl:for-each select="FlightTimeSummary/Missions/Mission">
                  <fo:table-row>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Id" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell number-columns-spanned="2"
                                   border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Name" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//From" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//To" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//TakeOff" />
                      </fo:block >
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Landing" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//FlightTime" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//TouchAndGos" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//FullStops" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Totals" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Sorties" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell number-columns-spanned="2"
                                   border-bottom=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//SpecialUse" />
                      </fo:block>
                    </fo:table-cell>
                  </fo:table-row>
                </xsl:for-each>
                <!-- Mission Grand Totals -->
                <fo:table-row>
                  <fo:table-cell number-columns-spanned="4"
                                 border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block text-align="left">
                      <fo:inline font-weight="bold">Operating Unit: </fo:inline>
                      <fo:inline>
                        <xsl:value-of select="FlightTimeSummary/OperatingUnit" />
                      </fo:inline>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 border-bottom=".01in solid black" />
                  <fo:table-cell number-columns-spanned="2"
                                 border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold"
                              text-align="left">
                      Grand Totals
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/TotalCalculatedFlightTime" />
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/TotalTouchAndGos" />
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/TotalFullStops" />
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/TotalTotals" />
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/TotalSorties" />
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="3" />
                </fo:table-row>
                <!-- Spacer Row -->
                <fo:table-row>
                  <fo:table-cell number-columns-spanned="14"
                                 border-bottom=".01in solid black"
                                 height=".25in">
                  </fo:table-cell>
                </fo:table-row>
                <!-- Squadron Header Row -->
                <fo:table-row>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Flying Unit</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">SSN</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Name</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Duty Code</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Prim</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Sec</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Instr</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Eval</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Other</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Total</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Sorties</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Primary Night</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Secondary Night</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-bottom=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">Simulated Inst</fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <!-- Squadron Data Rows -->
                <xsl:for-each select="FlightTimeSummary/Squadron/Member">
                  <fo:table-row>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//FlyingUnit" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//SSN" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Name" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//DutyCode" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Primary" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Secondary" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Instructor" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Evaluator" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Other" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Total" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//Sorties" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//PrimaryNight" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   border-right=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//PrimaryInstrument" />
                      </fo:block>
                    </fo:table-cell>
                    <fo:table-cell border-bottom=".01in solid black"
                                   padding=".05in">
                      <fo:block>
                        <xsl:value-of select=".//SimulatedInstrument" />
                      </fo:block>
                    </fo:table-cell>
                  </fo:table-row>
                </xsl:for-each>
                <!-- Final Row -->
                <fo:table-row>
                  <fo:table-cell border-right=".01in solid black" />
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">
                      Pilot Review
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/PilotReview"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block font-weight="bold">
                      Ops Review
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-right=".01in solid black"
                                 padding=".05in">
                    <fo:block>
                      <xsl:value-of select="FlightTimeSummary/OpsReview"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell number-columns-spanned="9" />
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
          <fo:block id="theEnd"/>
        </fo:flow>
      </fo:page-sequence>
    </fo:root>
  </xsl:template>
</xsl:stylesheet>
