<%@ Page Title="" Language="C#" MasterPageFile="~/AsteroidProject/MasterPage.master" AutoEventWireup="true" CodeFile="mapGuesser.aspx.cs" Inherits="Project_mapGuesser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPageBody" Runat="Server">
    <div class="row">
            <div class="col-lg">
                <h2 style="text-align:center">Map Guesser</h2>
                <br />
                <p id="quiz-description" style="text-align:center">Guess the location</p>
            </div>
        </div>
        <div class="row my-4">
            <div class="col-lg">
                <hr>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-lg">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-8">
                            <div id="map" class="" style="display:inline-block;width:100%;height:50vh;">
                                <%-- Map --%>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row justify-content-center">
                        <div class="col-md-8">
                            <form>
                                <label for="txt-country">Country</label>
                                <input type="text" class="form-control" id="txt-country" placeholder="What country is this?" />
                                <br />
                                <button type="button" id="btn-submit" class="btn btn-outline-primary mr-2" onclick="submitAnswer()">Submit</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="Server">
    <script src="./js/mapHandler.js" ></script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBVi43Dp9znUtd722ZcTtSsSidDQImZZso&callback=initMap">
    </script>
</asp:Content>

