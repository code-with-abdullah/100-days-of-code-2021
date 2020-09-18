$(document).ready(function(){
    let moves = 0;
    let check = 0;
    let lastMovesBy = 1;
    let grid = [[0,0,0],
                [0,0,0],
                [0,0,0]];

    const resetGrid = () => {
        grid = [[0,0,0],
                [0,0,0],
                [0,0,0]];
        $("#_00").text(" - ");
        $("#_01").text(" - ");
        $("#_02").text(" - ");
        $("#_10").text(" - ");
        $("#_11").text(" - ");
        $("#_12").text(" - ");
        $("#_20").text(" - ");
        $("#_21").text(" - ");
        $("#_22").text(" - ");
        moves = 0;
    }

    const checkIfGameEnded = () => {
        for(let i = 0; i < 3; i++){
            // row check
            if(grid[i][0] === grid[i][1] && grid[i][1] === grid[i][2]) {
                return grid[i][0];
            }

            // column check
            if(grid[0][i] === grid[1][i] && grid[1][i] === grid[2][i]){
                return grid[0][i];
            }
        }

        // Diagonal
        if(grid[0][0] === grid[1][1] && grid[1][1] === grid[2][2]){
            return grid[0][0];
        }

        if(grid[0][2] === grid[1][1] && grid[1][1] === grid[2][0]){
            return grid[1][1];
        }

        return 0;
    }

    $(".row>div").click(function() {
        if($(this).text() === " - ") {
            moves++;

            let x = $(this)[0].id[1];
            let y = $(this)[0].id[2];

            grid[x][y] = lastMovesBy;
            
            if(lastMovesBy === 1) {
                $(this).text('0');
                lastMovesBy = 2;
            } else {
                $(this).text('X');
                lastMovesBy = 1;
            }
        }
        console.log(grid);

        let check = checkIfGameEnded();
        if (check === 1) {
            $("#player-1-won").text(parseInt($("#player-1-won").text()) + 1);
            resetGrid();
        }
        else if (check === 2) {
            $("#player-2-won").text(parseInt($("#player-2-won").text()) + 1);
            resetGrid();
        }
        else if (check === 0 && moves === 9 ){
            $("#no-one-won").text(parseInt($("#no-one-won").text()) + 1);
            resetGrid();
        }

    });
});