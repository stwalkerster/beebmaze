﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;

namespace BeebMaze.Render
{
    public partial class Gl2MazeRenderScreen : GlMazeRenderScreen
    {
        private const float WIDTH_WALL = 2f,
                            WIDTH_CELL = 5f,
                            GL_SIZE = 2f;

        private Block[,] maze = new Block[0,0];

        public override void render(Block[,] maze)
        {
            this.maze = maze;
            simpleOpenGlControl1.Invalidate();
        }


        public Gl2MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "2D OpenGL");
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            simpleOpenGlControl1.Paint += simpleOpenGlControl1_Paint;
        }

        /// <summary>
        /// Handles the Paint event of the simpleOpenGlControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            // reset the projection and modelview matrices
            Gl.glMatrixMode(Gl.GL_PROJECTION_MATRIX);
            Gl.glLoadIdentity();

            Gl.glMatrixMode(Gl.GL_MODELVIEW_MATRIX);
            Gl.glLoadIdentity();

            int cols = 10;
            int rows = 30;

            //work out how much we have to scale this model by
            float xscalingfactor = getScalingFactor(cols),
                  yscalingfactor = getScalingFactor(rows);

            drawGridlines(cols, rows, xscalingfactor, yscalingfactor);

            float xpoint = -1,
                ypoint = -1;
            for (int j = 0; j < rows; j++)
            {
                ypoint += ((WIDTH_WALL / 2) * yscalingfactor);

                // draw upper walls/doors
                for (int i = 0; i < cols; i++)
                {
                    Gl.glLoadIdentity();

                    // iterate through cols
                    xpoint += ((WIDTH_WALL / 2) * xscalingfactor);


                    //draw wall
                    Gl.glTranslatef(xpoint, ypoint, 0);
                    drawQuad(getScalingFactor(cols));

                    xpoint += ((WIDTH_WALL / 2) * xscalingfactor);
                    xpoint += ((WIDTH_CELL / 2) * xscalingfactor);


                    // draw cell


                    xpoint += ((WIDTH_CELL / 2) * xscalingfactor);

                }
                ypoint += ((WIDTH_WALL / 2) * yscalingfactor);
                ypoint += ((WIDTH_CELL / 2) * yscalingfactor);

                xpoint = -1;
                //draw mid walls/cells
                for (int i = 0; i < cols; i++)
                {
                    // iterate through cols

                    // draw wall
                    // draw cell
                }

                // draw last col
                Gl.glLoadIdentity();
                Gl.glTranslatef(xpoint, ypoint, 0);
                drawQuad(getScalingFactor(cols));
                ypoint += ((WIDTH_CELL / 2) * yscalingfactor);

            }

            //draw bottom walls/doors
            for (int i = 0; i < cols; i++)
            {
                // iterate through cols

                // draw wall
                // draw cell
            }

            Gl.glFlush();
        }

        private static void drawGridlines(int cols, int rows, float xscalingfactor, float yscalingfactor)
        {
            float point = -1;
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(1, 0, 0);
            for (int i = 0; i < rows; i++)
            {
                Gl.glVertex2f(-1, point);
                Gl.glVertex2f(1, point);
                point += (WIDTH_WALL * yscalingfactor);
                Gl.glVertex2f(-1, point);
                Gl.glVertex2f(1, point);
                point += (WIDTH_CELL * yscalingfactor);
            }
            Gl.glVertex2f(-1, point);
            Gl.glVertex2f(1, point);
            Gl.glEnd();

            point = -1;

            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0, 1, 0);
            for (int i = 0; i < cols; i++)
            {
                Gl.glVertex2f(point, -1);
                Gl.glVertex2f(point, 1);
                point += (WIDTH_WALL * xscalingfactor);
                Gl.glVertex2f(point, -1);
                Gl.glVertex2f(point, 1);
                point += (WIDTH_CELL * xscalingfactor);
            }
            Gl.glVertex2f(point, -1);
            Gl.glVertex2f(point, 1);
            Gl.glEnd();
        }

        private float getScalingFactor(int cells)
        {
            return GL_SIZE/((WIDTH_WALL*(cells + 1)) + (cells*WIDTH_CELL));
        }

        void drawQuad(float size)
        {
            size = size/2;

            Gl.glBegin(Gl.GL_POLYGON);

            Gl.glColor3f(1f, 1f, 1f);

            Gl.glVertex2f(-size, size);
            Gl.glVertex2f(-size, -size);
            Gl.glVertex2f(size, -size);
            Gl.glVertex2f(size, size);

            Gl.glEnd();
        }
    }
}
