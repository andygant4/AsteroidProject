<%@ Page Title="" Language="C#" MasterPageFile="~/AsteroidProject/MasterPage.master" AutoEventWireup="true" CodeFile="Quiz.aspx.cs" Inherits="Project_ColorBlindTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderPageBody" Runat="Server">
      <div class="row">
            <div class="col-lg">
                <h2 style="text-align:center" id="quiz-title"></h2>
                <br />
                <p id="quiz-description" style="text-align:center"></p>
            </div>
        </div>
        <div class="row my-4">
            <div class="col-lg">
                <hr>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-6 align-content-center">
                <div class="container" id="question">
                    <p id="qText"></p>

                    <div class="row">
                        <div class="col justify-content-center">
                            <img class="rounded img-thumbnail my-4 d-block mx-auto" id="qImg">
                        </div>
                    </div>
                    <%--<%--
                    <div class="row">
                        <div class="col">
                            <div class="alert alert-success" role="alert"><strong>Correct! </strong></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="alert alert-danger" role="alert"><strong>Incorrect! </strong></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <div class="card choice-card" id="choice0" onclick="submitAnswer(0)">
                                <div class="card-body">
                                    <p></p>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card choice-card" id="choice1" onclick="submitAnswer(1)">
                                <div class="card-body">
                                    <p></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row my-4">
                        <div class="col">
                            <div class="card choice-card" id="choice2" onclick="submitAnswer(2)">
                                <div class="card-body">
                                    <p></p>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card choice-card" id="choice3" onclick="submitAnswer(3)">
                                <div class="card-body">
                                    <p></p>
                                </div>
                            </div>
                        </div>
                    </div>
                        -%>--%>
                    <div class="row my-4 justify-content-around">
                        <button type="button" class="btn btn-success nav-button" id="btnPrev">Previous</button>
                        <button type="button" class="btn btn-success nav-button" id="btnNext" >Next</button>
                                           <div class="col">
                            <div class="card choice-card" id="choice3" onclick="submitAnswer(3)"  >Next
                                <div class="card-body">
                        </div>
                                </div>
                                </div>
                </div>

            </div>
        </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="Server">
    <script src="./js/quizHandler.js" ></script>
</asp:Content>


