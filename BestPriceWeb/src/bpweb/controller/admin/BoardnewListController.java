package bpweb.controller.admin;

import java.io.IOException;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bpweb.model.Boardnew;
import bpweb.service.BoardnewService;
import bpweb.service.impl.BoardnewServicesImpl;

/**
 * Servlet implementation class CategoryListController
 */
//@WebServlet(urlPatterns = { "/admin/new/list" })
public class BoardnewListController extends HttpServlet{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	BoardnewService newService = new BoardnewServicesImpl();
	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		List<Boardnew> boardnewList = newService.getAll();
		req.setAttribute("boardnewlist", boardnewList);
		RequestDispatcher dispatcher = req.getRequestDispatcher("/view/admin/show-new.jsp");
		dispatcher.forward(req, resp);
	}
}
