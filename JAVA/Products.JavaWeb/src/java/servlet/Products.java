/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Norbert
 */
@WebServlet(name = "Products", urlPatterns = {"/Products"})
public class Products extends HttpServlet {
    static Random R=new Random();
    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/xml;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            String productName = request.getParameter("product");
            String shopName = request.getParameter("shop");
            if(productName == ""){
                productName = null;
            }
            if(shopName == ""){
                shopName = null;
            }
            
            if (productName == null && shopName != null){
                out.println("<productweb>");
                out.println("<product>"+"Mit keresel?"+"</product>");
                out.println("<shop>"+shopName+"</shop>");
                out.println("<prices>");
                out.println("<price>" + "Hiba: hiányos adatok!" + "</price>");
                out.println("</prices>");
                out.println("</productweb>");
            }
            else if (shopName == null && productName != null){
                out.println("<productweb>");
                out.println("<product>"+productName+"</product>");
                out.println("<shop>"+"Hol szeretnél vásárolni?"+"</shop>");
                out.println("<prices>");
                out.println("<price>" + "Hiba: hiányos adatok!" + "</price>");
                out.println("</prices>");
                out.println("</productweb>");
            }
            else if (shopName == null && productName == null){
                out.println("<productweb>");
                out.println("<product>"+"Mit keresel?"+"</product>");
                out.println("<shop>"+"Hol szeretnél vásárolni?"+"</shop>");
                out.println("<prices>");
                out.println("<price>" + "Hiba: hiányos adatok!" + "</price>");
                out.println("</prices>");
                out.println("</productweb>");
            }
            else{
                out.println("<productweb>");
                out.println("<product>"+productName+"</product>");
                out.println("<shop>"+shopName+"</shop>");
                out.println("<prices>");
                for (int i = 0; i < 5; i++) {
                    out.println("<price>" + (R.nextInt(2000)+1) + "</price>");
                }
                out.println("</prices>");
                out.println("</productweb>");
            }

        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
