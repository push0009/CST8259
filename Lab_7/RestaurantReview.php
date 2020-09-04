<?php
$xml = simplexml_load_file("test.xml") or die("Error: Cannot create object");
//print_r($xml->Restaurant[1]->Address);
?>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function(){
            $('#mySelect').change(function(){
                myform.submit();
            });
        });
    </script>
</head>
<body>
<h1>Lab 4</h1>
<form action="" method="POST" name="myform">
        <select name="drpList" id="mySelect">
            <?php
            $hui = 0;
            $pizda = array();
            foreach ($xml->children() as $item){ //$pizda[$hui] = $item->Name;?>
            <option value="<?php echo $hui?>"><?php echo $item->Name;?></option>
            <?php
            $hui = $hui + 1;}
            ?>
        </select>
    <?php
    if($_SERVER["REQUEST_METHOD"] = "POST") {
        $val = $_POST['drpList'];
        $convrt = (int)$val;
        $rating = $xml->Restaurant[$convrt]->Reviews->Review->Rating;
        $iRating = (int)$rating; ?>
        <h4>Address: </h4>
        <textarea id="textarea1" disabled name="address">
            <?php
//            $xmlApt = $xml->Restaurant[$convrt]->Address->AptNumber . " ";
//            $xmlStreet = $xml->Restaurant[$convrt]->Address->Street . ", ";
//            $xmlSuburb = $xml->Restaurant[$convrt]->Address->Suburb . ", ";
//            $xmlProvince = $xml->Restaurant[$convrt]->Address->Province . ", ";
//            $xmlPostal = $xml->Restaurant[$convrt]->Address->Postal . " ";
//            $xmlAddress = $xmlApt.$xmlStreet.$xmlSuburb.$xmlProvince.$xmlPostal;
            $data = '{
                "aptNumber": $xml->Restaurant[$convrt]->Address->AptNumber,
            }';
            $character = json_decode($data);
            echo $character;
//            echo $xml->Restaurant[$convrt]->Address->AptNumber . " ";
//            echo $xml->Restaurant[$convrt]->Address->Street . ", ";
//            echo $xml->Restaurant[$convrt]->Address->Suburb . ", ";
//            echo $xml->Restaurant[$convrt]->Address->Province . ", ";
//            echo $xml->Restaurant[$convrt]->Address->Postal . " ";
            ?>
        </textarea>
        <h4>Summary: </h4>
        <textarea id="textarea2" name="summary">
            <?php
            echo $xml->Restaurant[$convrt]->Reviews->Review->Summary;
            ?>
        </textarea>
        <h4>Rating: </h4>
        <select name="drpRating">
            <?php
            $aRating = array(1, 2, 3, 4, 5);
            foreach ($aRating as $value) {
                if ($value == $iRating) {
                    echo '<option selected value="' . $value . '">' . $value . '</option>';
                } else {
                    echo '<option value="' . $value . '">' . $value . '</option>';
                }
            }
            ?>
        </select>
        <br>
        <br>
        <input type="submit" id="save" name="btnSave" value="Save Changes">
        <?php
        if(isset($_POST['btnSave'])){
            $txtSummary = $_POST["summary"];
            $txtRating = $_POST["drpRating"];
            $xml->Restaurant[$convrt]->Reviews->Review->Summary = $txtSummary;
            $xml->Restaurant[$convrt]->Reviews->Review->Rating = $txtRating;
            $xml->asXML('test.xml');
            echo "<p>All good</p>";
        }
    }?>

</form>
</body>
</html>