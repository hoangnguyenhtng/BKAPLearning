// Pacman.java applet for ICS80J Lab 4, Fall 2002

// Recoded to use Graphics2D by Norman Jacobson, September 2002.
// Derived from code by Eamonn Keogh written September 1997.


import java.awt.*;
import java.awt.geom.*;
import java.applet.*;
import java.util.Random;

public class pacman extends Applet
{
	// location of the pink pill
	public static int pinkPillPosition;

    // init(): called once, when applet is first invoked
    //         clears the layout (wipes the window clean) and
    //         set its size
	public void init()
	{
		setLayout(null);
		resize(500,300);
	}

    //paint(): called by Applet each time the graphics window changes
    //         draws the maze and moves the Pacman through it
	public void paint(Graphics g)
	{

		Graphics2D g2 = (Graphics2D)g;	// Enable use of Graphics2d

		int pacManAngle  =   0;     // Pacman's starting angle
		int pacManCoordX =  40;     // Pacman's starting X coordinate
		int pacManCoordY = 270;     // Pacman's starting Y coordinate

	   	drawMaze(g2);                 // Draw the maze

//------------------------- Do NOT change anything above this line!! -----------------------------
//---------------------         Replace code below this line...          -------------------------

		int loopCount;

		// Sample code, to demo Pacman turning (450 degrees)
		for(loopCount = 0; loopCount <= 150; loopCount++)
		{
		    pacManAngle +=3;                                                    // Change...
		    drawPacman(g2, pacManCoordX,pacManCoordY,pacManAngle,Color.yellow); // Paint...
		    pause(80);                                                          // Wait.. .
		    drawPacman(g2, pacManCoordX,pacManCoordY,pacManAngle,Color.black);  // Erase.
		}

		// Sample code, to demo Pacman moving (in the Y axis)
		for(loopCount = 0; loopCount < 120;loopCount++)
		{
		    pacManCoordY -=2;                                                    // Change...
		    drawPacman(g2, pacManCoordX,pacManCoordY,pacManAngle,Color.yellow);  // Paint...
		    pause(80);                                                           // Wait...
		    drawPacman(g2, pacManCoordX,pacManCoordY,pacManAngle,Color.black);   // Erase.
		}


		drawPacman(g2,pacManCoordX,pacManCoordY,pacManAngle,Color.yellow);       // Show Pacman
		                                                                         // in final position
	}

//----------    ... and above this line to make Pacman go through the maze        ----------------
//------------------------- Do NOT change anything below this line!! -----------------------------

    // drawPacman(): create a PacMan amd draw it (the drawing stays until erased)
	public void drawPacman(Graphics2D p, int centerX, int centerY, int angle, Color c)
	{
		Arc2D.Double pacman = new Arc2D.Double();
		pacman.setArc(centerX-20,centerY-20,40,40,(angle % 360)+30, 300, Arc2D.PIE);
		p.setPaint(c);
		p.fill(pacman);
	}


    // drawMaze(): draws the maze
	public void drawMaze(Graphics2D maze)
	{

    	// Randomly set the Y position of the Pink Pill between pixels 90 and 240
    	Random generator = new Random();
		pinkPillPosition = 90 + generator.nextInt(151);

		// Make the background black
	    maze.setPaint(Color.black);
	    Rectangle background = new Rectangle(0, 0, 500, 300);
	    maze.fill(background);

	    maze.setPaint(Color.blue);         // Set wall color to blue

	    //First wall
		Line2D.Double currentLine = new Line2D.Double (80, 300, 80, 80);
		maze.draw(currentLine);
		currentLine.setLine(120, 300, 120, 80);
		maze.draw(currentLine);
		Arc2D.Double bend = new Arc2D.Double(80, 60, 40, 40, 0, 180, Arc2D.OPEN);
		maze.draw(bend);

		//Second wall
		currentLine.setLine(180, 0, 180, 220);
		maze.draw(currentLine);
		currentLine.setLine(320, 0,320,180);
		maze.draw(currentLine);
		currentLine.setLine(208,238, 306,199);
		maze.draw(currentLine);
		bend.setArc(180,200,40,40,180,110, Arc2D.OPEN);
		maze.draw(bend);
		bend.setArc(280,160,40,40,285,75, Arc2D.OPEN);
		maze.draw(bend);
		currentLine.setLine(208, 304, 364, 245);
		maze.draw(currentLine);

		//Third wall
		currentLine.setLine(380, 224, 380, 100);
		maze.draw(currentLine);
		currentLine.setLine(420, 300, 420, 100);
		maze.draw(currentLine);
		bend.setArc(380,80,40,40,0,180, Arc2D.OPEN);
		maze.draw(bend);
		bend.setArc(341,206,40,40,280,90, Arc2D.OPEN);
		maze.draw(bend);

		//Bump wall
		bend.setArc(380,-20,40,40,180,180, Arc2D.OPEN);
		maze.draw(bend);

		//Draw energy pills and the pink power pill
		maze.setPaint(Color.white);
		Ellipse2D.Double pill = new Ellipse2D.Double(40,100,4,4);
		maze.fill(pill);
		pill.setFrame(150,100,4,4);
		maze.fill(pill);
		pill.setFrame(150,100,4,4);
		maze.fill(pill);
		pill.setFrame(150,200,4,4);
		maze.fill(pill);
		pill.setFrame(250,250,4,4);
		maze.fill(pill);
		pill.setFrame(250,250,4,4);
		maze.fill(pill);

		maze.setColor(Color.pink);
		pill.setFrame(460,pinkPillPosition,8,8);
		maze.fill(pill);
	}


    //pause(): pause the action
	public void pause(int sleepTime)
	{    for(int j = 0; j<= sleepTime; j++)
	        for(long i = 0; i < 3000; i++) {;}
	}
}