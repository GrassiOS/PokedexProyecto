//
//  DownButtonView.swift
//  Pokedex Test
//
//  Created by Martin on 29/07/23.
//

import SwiftUI

struct DownButtonView: View {
    
    @Binding var currentPage: Int
    
    var body: some View {
        HStack(spacing: 25) {
            //left
            Button {
                if currentPage > 1 {
                    currentPage-=1
                }
            } label: {
                Image(systemName: "arrowtriangle.left.fill")
                    .resizable()
                    .scaledToFill()
                    .foregroundColor(.red)
                    .frame(width: 35, height: 33)
            }

            //pokemon
            
            Button {
                currentPage=1
            } label: {
                Image("pkebtn")
                    .resizable()
                    .scaledToFill()
                    .foregroundColor(.red)
                    .frame(width: 50, height: 33)
            }
            
            Button {
                if currentPage < 24 {
                    currentPage+=1
                }
            } label: {
                Image(systemName: "arrowtriangle.right.fill")
                    .resizable()
                    .scaledToFill()
                    .foregroundColor(.red)
                    .frame(width: 35, height: 33)
            }
            //right
        }
        .shadow(color: .red.opacity(0.3), radius: 10, x: 0, y: 0)
    }
}

struct DownButtonView_Previews: PreviewProvider {
    static var previews: some View {
        DownButtonView(currentPage: .constant(4))
    }
}
