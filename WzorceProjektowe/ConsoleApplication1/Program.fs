open System
open System.Drawing
open System.Windows.Forms
open Microsoft.FSharp.Control
open Microsoft.FSharp.Core.Operators

let width = 540
let height = 600
let mutable width2 = 0
let mutable height2 = 0
let a = 40
let mutable move = 0
let mutable position = 0
let mutable position2 = 0
let mutable positionleft = 0
let mutable positionright = 0
let mutable globalrandom = 0
let mutable globalfigure = 0
let mutable color = System.Drawing.Color.LightGray
let mutable color2 = System.Drawing.Color.LightGray
let mutable points = 0
let rnd = System.Random()
let mutable (table : int [,]) = Array2D.zeroCreate<int> 14 13
let exercise = new Form(FormBorderStyle = FormBorderStyle.FixedSingle, Size = new Size(width, height), BackColor=System.Drawing.Color.LightGray)

let stuffToDoWhenKeyPressed s (f : KeyEventArgs) = async {
        match f with
        | f when f.KeyCode = Windows.Forms.Keys.Left -> if globalfigure <> 0 && globalfigure <> 1 && globalfigure <> 4 then 
                                                            if move-a > -240 then move <- move - a
                                                        elif move > -240 then move <- move - a
        
        | f when f.KeyCode = Windows.Forms.Keys.Right -> if globalfigure = 2 || globalfigure = 4 || globalfigure = 6  || globalfigure = 7 then 
                                                            if move+a <=200 then move <- move + a
                                                         elif move <= 200 then move <- move + a } |> Async.RunSynchronously

exercise.KeyDown.AddHandler(new System.Windows.Forms.KeyEventHandler (fun s f -> stuffToDoWhenKeyPressed s f ))

let matchrnd(randomNumber) =
      match randomNumber with
        | 1 -> color2 <- System.Drawing.Color.Green
        | 2 -> color2 <- System.Drawing.Color.Red
        | 3 -> color2 <- System.Drawing.Color.Blue
        | 4 -> color2 <- System.Drawing.Color.Black
        | 5 -> color2 <- System.Drawing.Color.White
        | 6 -> color2 <- System.Drawing.Color.Orange 
        | 7 -> color2 <- System.Drawing.Color.Yellow
        | 8 -> color2 <- System.Drawing.Color.Pink

let findcolor () =
    let randomNumber = rnd.Next(1,8)
    globalrandom <- randomNumber
    match globalrandom with
        | 1 -> color <- System.Drawing.Color.Green
        | 2 -> color <- System.Drawing.Color.Red
        | 3 -> color <- System.Drawing.Color.Blue
        | 4 -> color <- System.Drawing.Color.Black
        | 5 -> color <- System.Drawing.Color.White
        | 6 -> color <- System.Drawing.Color.Orange 
        | 7 -> color <- System.Drawing.Color.Yellow
        | 8 -> color <- System.Drawing.Color.Pink

let findfigure () =
    findcolor()
    let randomNumber2 = rnd.Next(1,7)
    globalfigure <- randomNumber2

let matchfigure (position, position2) =
    match globalfigure with
        | 1 -> table.[position-3,position2] <- globalrandom; //table.[0,6] 
               table.[position-2,position2] <- globalrandom; //table.[1,6] 
               table.[position-1,position2] <- globalrandom; //table.[2,6] 
               table.[position,position2] <- globalrandom    //table.[3,6]
        
        | 2 -> table.[position-1,position2-1] <- globalrandom; //table.[0,5] 
               table.[position-1,position2] <- globalrandom; //table.[0,6] <- globalrandom;
               table.[position-1,position2+1] <- globalrandom; //table.[0,7] <- globalrandom;
               table.[position,position2] <- globalrandom //table.[1,6] <- globalrandom

        | 3 -> table.[position-1,position2-1] <- globalrandom; //table.[0,5] <- globalrandom;
               table.[position-1,position2] <- globalrandom; //table.[0,6] <- globalrandom;
               table.[position,position2-1] <- globalrandom; //table.[1,5] <- globalrandom;
               table.[position,position2] <- globalrandom //table.[1,6] <- globalrandom

        | 4 -> table.[position-2,position2] <- globalrandom; //table.[0,6] <- globalrandom;
               table.[position-1,position2] <- globalrandom; //table.[1,6] <- globalrandom;
               table.[position,position2] <- globalrandom; //table.[2,6] <- globalrandom;
               table.[position,position2+1] <- globalrandom //table.[2,7] <- globalrandom
        
        | 5 -> table.[position-2,position2] <- globalrandom; //table.[0,6] <- globalrandom;
               table.[position-1,position2] <- globalrandom; //table.[1,6] <- globalrandom;
               table.[position,position2] <- globalrandom; //table.[2,6] <- globalrandom;
               table.[position,position2-1] <- globalrandom //table.[2,5] <- globalrandom

        | 6 -> table.[position-1,position2] <- globalrandom; //table.[0,6] <- globalrandom;
               table.[position-1,position2+1] <- globalrandom; //table.[0,7] <- globalrandom;
               table.[position,position2-1] <- globalrandom; //table.[1,5] <- globalrandom;
               table.[position,position2] <- globalrandom //table.[1,6] <- globalrandom

        | 7 -> table.[position-1,position2-1] <- globalrandom; //table.[0,5] <- globalrandom;
               table.[position-1,position2+1] <- globalrandom; //table.[0,6] <- globalrandom;
               table.[position,position2+1] <- globalrandom; //table.[1,6] <- globalrandom;
               table.[position,position2+2] <- globalrandom //table.[1,7] <- globalrandom

let findposition (move) =
    position <- move/40

let findposition2 (move) =
    match move with
        | -240 -> position2 <- 0
        | -200 -> position2 <- 1
        | -160 -> position2 <- 2
        | -120 -> position2 <- 3
        | -80 -> position2 <- 4
        | -40 -> position2 <- 5
        | 0 -> position2 <- 6
        | 40 -> position2 <- 7
        | 80 -> position2 <- 8
        | 120 -> position2 <- 9
        | 160 -> position2 <- 10
        | 200 -> position2 <- 11
        | 240 -> position2 <- 12

let findpositionleft (move) =
    match move with
        | -240 -> positionleft <- 0
        | -200 -> positionleft <- 1
        | -160 -> positionleft <- 2
        | -120 -> positionleft <- 3
        | -80 -> positionleft <- 4
        | -40 -> positionleft <- 5
        | 0 -> positionleft <- 6
        | 40 -> positionleft <- 7
        | 80 -> positionleft <- 8
        | 120 -> positionleft <- 9
        | 160 -> positionleft <- 10
        | 200 -> positionleft <- 11
        | 240 -> positionleft <- 12

let findpositionright (move) =
    match move with
        | -240 -> positionright <- 0
        | -200 -> positionright <- 1
        | -160 -> positionright <- 2
        | -120 -> positionright <- 3
        | -80 -> positionright <- 4
        | -40 -> positionright <- 5
        | 0 -> positionright <- 6
        | 40 -> positionright <- 7
        | 80 -> positionright <- 8
        | 120 -> positionright <- 9
        | 160 -> positionright <- 10
        | 200 -> positionright <- 11
        | 240 -> positionright <- 12

let getheight(move) =
    height2 <- move*a

let getwidth(move) =
    width2 <- move*a

let exercisePaint(e : PaintEventArgs) =
   
   System.Diagnostics.Debug.Write(points)

   let placeboxes() =
     for i in 0..13 do
         getheight(i)
         for j in 0..12 do
            if table.[i,j] <> 0 then 
                matchrnd(table.[i,j])
                getwidth(j)
                e.Graphics.FillRectangle(new SolidBrush(color2), new System.Drawing.Rectangle(width2, height2, a, a))
  
   let drawrectangles(i) =
     match globalfigure with
            | 1 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+2)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+3)*a, a, a))
            
            | 2 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10-a, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10+a, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a))
        
            | 3 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10-a, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10-a, (i+1)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a))
        
            | 4 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+2)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10+a, (i+2)*a, a, a))
        
            | 5 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+2)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10-a, (i+2)*a, a, a))
       
            | 6 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10+a, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10-a, (i+1)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a))
        
            | 7 ->  e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10-a, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, i*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10, (i+1)*a, a, a));
                    e.Graphics.FillRectangle(new SolidBrush(color), new System.Drawing.Rectangle(width/2-a/2+move-10+a, (i+1)*a, a, a))

   let rec gameloop() = async{
     let event = new System.Threading.AutoResetEvent(false)
     let timer = new System.Timers.Timer(1000.0)
     timer.Elapsed.Add (fun _ -> event.Set() |> ignore )
     move <- 0
     findfigure()
     let mutable i = 0
     while i<=13 do
        placeboxes()
        //e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Brown), new System.Drawing.Rectangle(width, 0, 100, height));
        Application.DoEvents();
        drawrectangles(i)
        timer.Start()
        event.WaitOne() |> ignore
        e.Graphics.Clear(System.Drawing.Color.LightGray)
        
        findposition2(move)

        if globalfigure = 4 || globalfigure = 5 then findposition((i+2)*a)
        elif globalfigure = 1 then findposition((i+3)*a)
        else findposition((i+1)*a)
       
        if globalfigure = 4 then findpositionleft(move); findpositionright(move+40)
        elif globalfigure = 5 || globalfigure = 3 then findpositionleft(move-40); findpositionright(move)
        elif globalfigure = 7 || globalfigure = 6 || globalfigure = 2 then findpositionleft(move-40); findpositionright(move+40)

        if position=13 then i<-14

        if position<13 then 
            if globalfigure = 1  && table.[position+1,position2] <>0 then i <- 14
            elif globalfigure = 2 && (table.[position,positionleft] <> 0  || table.[position,positionright] <> 0 || table.[position+1,position2] <>0) then i <- 14
            elif globalfigure = 3 && (table.[position+1,positionleft] <> 0 || table.[position+1,position2] <>0) then i <- 14
            elif globalfigure = 4 && (table.[position+1,positionright] <> 0 || table.[position+1,position2] <>0) then i <- 14
            elif globalfigure = 5 && (table.[position+1,positionleft] <> 0 || table.[position+1,position2] <>0) then i <- 14
            elif globalfigure = 6 && (table.[position+1,positionleft] <> 0 || table.[position,positionright] <> 0 || table.[position+1,position2] <>0) then i <- 14
            elif globalfigure = 7 && (table.[position+1,positionright] <> 0 || table.[position,positionleft] <> 0 || table.[position+1,position2] <>0) then i <- 14
            else i <- i+1

     matchfigure(position,position2)
     for i in 0..12 do
        if table.[0,i] <> 0 then table <- Array2D.zeroCreate<int> 14 13
     
     for i in 0..13 do
          let mutable count = 0
          for j in 0..12 do
            if table.[i,j]<>0 then count <- count + 1
          if count = 13 then  
               System.Diagnostics.Debug.Write("\n")
               System.Diagnostics.Debug.Write(points+13)
               let mutable l = i+1
               while l>0 do
                l <- l-1
                for k in 0..12 do            
                   if l = 0 then table.[l,k] <- 0
                   else table.[l,k] <- table.[l-1,k]
     return! gameloop()}     
     
   do gameloop() |> Async.StartImmediate

exercise.Paint.Add exercisePaint
do Application.Run exercise